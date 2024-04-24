import { useContext, useEffect, useState } from "react"
import { contextProp } from "../context/context"
import { SaveTask, getUsuarios, updateTask } from "../coneccions/api";
import axios from "axios";
import toast, { Toaster } from 'react-hot-toast';

export const CreateTaskDialog = ({onPress}) => {
    const { valueDialog, responseData } = useContext(contextProp)
    const [nameTask, setNameTask] = useState('');
    const [description, setDescription] = useState('');
    const [startTime, setStartTime] = useState(new Date().toISOString()); 
    const [endTime, setEndTime] = useState(new Date().toISOString()); 
    const [usersavailable, setUsersavailable] = useState([]);
    const [userSelected, setSelected] = useState(0); 

    const handleChange = (e) => {
        setSelected(e.target.value); 
    };
    
    useEffect(()=>{
        if(usersavailable){
            axios.get(getUsuarios)
            .then(response => {
                console.log('Datos recibidos:', response.data);
                if(response && response.data){
                    setUsersavailable(response.data)
                }else{
                    alert("La respuesta no contiene datos.");
                }
            })
            .catch(error => {
                console.error('Error al obtener datos:', error);
            });
        }
    },[])

    const handleSubmit = () => {
        const data = {
            nameTask: nameTask,
            description: description,
            startTime: startTime,
            endTime: endTime,
            statusId: 1,
            userCreateId: responseData.idUser,
            ownerUserId: userSelected
        };

        axios.post(SaveTask, data)
        .then(response => {
            console.log('Datos recibidos:', response.data);
            toast.success("Tarea Guardada con exito.")
        })
        .catch(error => {
            console.error('Error al obtener datos:', error);
        });
    };

    return (
        valueDialog ? (
        <dialog className="bg-slate-800 h-full w-full bg-opacity-80 flex justify-center items-center" onSubmit={handleSubmit}>
            <div class="relative py-3 sm:max-w-xl sm:mx-auto">
                <div class={`relative px-4 py-10 bg-white mx-8 md:mx-0 shadow rounded-3xl sm:p-10 ${valueDialog ? 'animate-jump-in' : ''}`}>
                    <div class="max-w-md mx-auto">
                        <div class="flex items-center space-x-5">
                            <div class="h-14 w-14 bg-yellow-200 rounded-full flex flex-shrink-0 justify-center items-center text-yellow-500 text-2xl font-mono">i</div>
                            <div class="block pl-2 font-semibold text-xl self-start text-gray-700">
                                <h2 class="leading-relaxed">Create an Event</h2>
                                <p class="text-sm text-gray-500 font-normal leading-relaxed">Complete the fields to add a task.</p>
                            </div>
                        </div>
                        <div class="divide-y divide-gray-200">
                            <div class="py-8 text-base leading-6 space-y-4 text-gray-700 sm:text-lg sm:leading-7">
                                <div class="flex flex-col">
                                    <label class="leading-loose">Title</label>
                                    <input type="text" onChange={(e) => setNameTask(e.target.value)} class="bg-transparent px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" placeholder="Event title" />
                                </div>
                                <div class="flex flex-col">
                                    <label class="leading-loose">Description</label>
                                    <input type="text" onChange={(e) => setDescription(e.target.value)} class="bg-transparent px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" placeholder="Optional" />
                                </div>
                                <div class="flex items-center space-x-4">
                                    <div class="flex flex-col">
                                        <label class="leading-loose">Start</label>
                                        <div class="relative focus-within:text-gray-600 text-gray-400">
                                            <input type="date" onChange={(e) => setStartTime(e.target.value)} class="bg-transparent pr-4 pl-10 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" placeholder="YYYY-MM-DD" />
                                            <div class="absolute left-3 top-2">
                                                <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z"></path></svg>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="flex flex-col">
                                        <label class="leading-loose">End</label>
                                        <div class="relative focus-within:text-gray-600 text-gray-400">
                                            <input type="date" onChange={(e) => setEndTime(e.target.value)} class="bg-transparent pr-4 pl-10 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" placeholder="26/02/2020" />
                                            <div class="absolute left-3 top-2">
                                                <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z"></path></svg>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="flex flex-col">
                                        <label class="leading-loose">Choose User for Task</label>
                                        <select value={userSelected} onChange={handleChange} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
                                        >
                                            <option>Choose User</option>
                                            {usersavailable.map(item => (
                                                <option key={item.idUser} value={item.idUser}>
                                                    {item.name}
                                                </option>
                                            ))}
                                        </select>
                                    </div>
                            </div>
                            <div class="pt-4 flex items-center space-x-4">
                                <button onClick={onPress} class="flex justify-center items-center w-full text-gray-900 bg-transparent hover:bg-slate-600 px-4 py-3 rounded-md focus:outline-none">
                                    <svg class="w-6 h-6 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"></path></svg> Cancel
                                </button>
                                <button onClick={() => handleSubmit()} class="bg-blue-500 flex justify-center items-center w-full text-white px-4 py-3 rounded-md focus:outline-none">Create</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </dialog>
        ):null
    )
}

export const EditTaskDialog = ({onPress}) => {
    const { editDialog, responseData, setEditDialog, infoEdit, setInfoEdit} = useContext(contextProp)
    const [nameTask, setNameTask] = useState('');
    const [description, setDescription] = useState('');
    const [startTime, setStartTime] = useState(new Date().toISOString()); 
    const [endTime, setEndTime] = useState(new Date().toISOString()); 
    const [usersavailable, setUsersavailable] = useState([]);
    const [userSelected, setSelected] = useState(0); 

    const handleChange = (e) => {
        setSelected(e.target.value); 
    };

    
    useEffect(()=>{
        if(usersavailable){
            axios.get(getUsuarios)
            .then(response => {
                console.log('Datos recibidos:', response.data);
                if(response && response.data){
                    setUsersavailable(response.data)
                }else{
                    alert("La respuesta no contiene datos.");
                }
            })
            .catch(error => {
                console.error('Error al obtener datos:', error);
            });
        }
    },[])

    const handleCloseModal = () => {
        setEditDialog(false)
        setInfoEdit([])
    }

    const handleSubmit = () => {
        const data = {
            nameTask: nameTask,
            description: description,
            startTime: startTime,
            endTime: endTime,
            statusId: 1,
            userCreateId: responseData.idUser,
            ownerUserId: userSelected 
        };

        axios.post(SaveTask, data)
        .then(response => {
            console.log('Datos recibidos:', response.data);
        })
        .catch(error => {
            console.error('Error al obtener datos:', error);
        });
    };
    
    const handleSubmitUpdate = () => {
        const data = {
            idTask: infoEdit.idTask,
            nameTask: infoEdit.nameTask,
            description: description,
            startTime: startTime,
            endTime: endTime,
            statusId: infoEdit.statusId,
            userCreateId: responseData.idUser,
            ownerUserId: userSelected || infoEdit.ownerUserId
        };

        axios.post(updateTask, data)
        .then(response => {
            console.log('Datos recibidos:', response.data);
        })
        .catch(error => {
            console.error('Error al obtener datos:', error);
        });
    };
    return (
        editDialog ? (
        <dialog className="bg-slate-800 h-full w-full bg-opacity-80 flex justify-center items-center" onSubmit={handleSubmit}>
            <div class="relative py-3 sm:max-w-xl sm:mx-auto">
                <div class={`relative px-4 py-10 bg-white mx-8 md:mx-0 shadow rounded-3xl sm:p-10 ${editDialog ? 'animate-jump-in' : ''}`}>
                    <div class="max-w-md mx-auto">
                        <div class="flex items-center space-x-5">
                            <div class="h-14 w-14 bg-yellow-200 rounded-full flex flex-shrink-0 justify-center items-center text-yellow-500 text-2xl font-mono">i</div>
                            <div class="block pl-2 font-semibold text-xl self-start text-gray-700">
                                <h2 class="leading-relaxed">Edit Event</h2>
                                <p class="text-sm text-gray-500 font-normal leading-relaxed">Complete the fields to change a task.</p>
                            </div>
                        </div>
                        <div class="divide-y divide-gray-200">
                            <div class="py-8 text-base leading-6 space-y-4 text-gray-700 sm:text-lg sm:leading-7">
                                <div class="flex flex-col">
                                    <label class="leading-loose">Title</label>
                                    <input type="text" value={nameTask || infoEdit.nameTask}  onChange={(e) => setNameTask(e.target.value)} class="bg-transparent px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" placeholder="Event title" />
                                </div>
                                <div class="flex flex-col">
                                    <label class="leading-loose">Description</label>
                                    <input type="text" value={description || infoEdit.description} onChange={(e) => setDescription(e.target.value)} class="bg-transparent px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" placeholder="Optional" />
                                </div>
                                <div class="flex items-center space-x-4">
                                    <div class="flex flex-col">
                                        <label class="leading-loose">Start</label>
                                        <div class="relative focus-within:text-gray-600 text-gray-400">
                                            <input type="date" value={startTime || infoEdit.startTime}  onChange={(e) => setStartTime(e.target.value)} class="bg-transparent pr-4 pl-10 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" placeholder="YYYY-MM-DD" />
                                            <div class="absolute left-3 top-2">
                                                <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z"></path></svg>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="flex flex-col">
                                        <label class="leading-loose">End</label>
                                        <div class="relative focus-within:text-gray-600 text-gray-400">
                                            <input type="date" value={endTime || infoEdit.endTime}  onChange={(e) => setEndTime(e.target.value)} class="bg-transparent pr-4 pl-10 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" placeholder="YYYY-MM-DD" />
                                            <div class="absolute left-3 top-2">
                                                <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z"></path></svg>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="flex flex-col">
                                        <label class="leading-loose">Choose User for Task</label>
                                        <select value={userSelected || infoEdit.ownerUserId} onChange={handleChange} className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
                                        >
                                            <option>Choose User</option>
                                            {usersavailable.map(item => (
                                                <option key={item.idUser} value={item.idUser}>
                                                    {item.name}
                                                </option>
                                            ))}
                                        </select>
                                    </div>
                            </div>
                            <div class="pt-4 flex items-center space-x-4">
                                <button onClick={handleCloseModal} class="flex justify-center items-center w-full text-gray-900 bg-transparent hover:bg-slate-600 px-4 py-3 rounded-md focus:outline-none">
                                    <svg class="w-6 h-6 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"></path></svg> Cancel
                                </button>
                                    {setInfoEdit.length > 0 ? (
                                        <button onClick={() => handleSubmitUpdate()} className="bg-blue-500 flex justify-center items-center w-full text-white px-4 py-3 rounded-md focus:outline-none">Update</button>
                                    ) : (
                                        <button onClick={() => handleSubmit()} className="bg-blue-500 flex justify-center items-center w-full text-white px-4 py-3 rounded-md focus:outline-none">Create</button>
                                    )}                            
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </dialog>
        ):null
    )
}



export const ShowInformation = ({onPress}) => {
    const { showinformation, setShowInformacion, info, valueSearch,setInfo,setValueSearch} = useContext(contextProp)
    const [ showData, setShowData ] = useState([])




    const item = info.find(item => item.idTask === valueSearch);
    
    useEffect(()=>{
        setShowData(item);
    },[item])
   

    console.log("soy data")
    console.log(showData?.nameTask)
    console.log("soy data")

    const handleCloseModal = () => {
        setShowInformacion(false)
        setInfo([])
        setValueSearch([])
    }



    return (
        showinformation ? (
        <dialog className="bg-slate-800 h-full w-full bg-opacity-80 flex justify-center items-center">
            <div class="relative py-3 sm:max-w-xl sm:mx-auto">
                <div class={`relative px-4 py-10 bg-white mx-8 md:mx-0 shadow rounded-3xl z-30 sm:p-10 ${showinformation ? 'animate-jump-in' : ''}`}>
                    <div class="max-w-md mx-auto">
                        <div class="flex items-center space-x-5">
                            <div class="h-14 w-14 bg-blue-200 rounded-full flex flex-shrink-0 justify-center items-center text-white-500 text-2xl font-mono">i</div>
                            <div class="block pl-2 font-semibold text-xl self-start text-gray-700">
                                <h2 class="leading-relaxed">Info Event</h2>
                                <p class="text-sm text-gray-500 font-normal leading-relaxed">Complete the fields to change a task.</p>
                            </div>
                        </div>
                        <div class="divide-y divide-gray-200">
                            <div class="py-8 text-base leading-6 space-y-4 text-gray-700 sm:text-lg sm:leading-7">
                                <div class="flex flex-col">
                                    <label class="leading-loose">Title</label>
                                    <input disabled type="text" value={showData?.nameTask} class="bg-slate-400 px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" placeholder="Event title" />
                                </div>
                                <div class="flex flex-col">
                                    <label class="leading-loose">Description</label>
                                    <input disabled type="text" value={showData?.description} class="bg-slate-400 px-4 py-2 border focus:ring-gray-500 focus:border-gray-900 w-full sm:text-sm border-gray-300 rounded-md focus:outline-none text-gray-600" placeholder="Optional" />
                                </div>
                            </div>
                            <div class="pt-4 flex items-center space-x-4">
                                <button onClick={handleCloseModal} class="flex justify-center items-center w-full text-gray-900 bg-transparent hover:bg-slate-600 px-4 py-3 rounded-md focus:outline-none">
                                    <svg class="w-6 h-6 mr-3" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"></path></svg> Cancel
                                </button>                             
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </dialog>
        ):null
    )
}