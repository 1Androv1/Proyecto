import './styles.css'; 
import { filterTask } from "../coneccions/api";
import axios from 'axios';
import { useContext, useState } from 'react';
import { TasItemSearch } from './TaskItem';
import { contextProp } from '../context/context';

export const SearchTask = () => {
    const [searchTask, setSearchTask] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const { setShowInformacion, setValueSearch } = useContext(contextProp)

    const handleSubmit = () => {
        const filtro = searchTask;

        axios.get(filterTask + filtro)
            .then(response => {
                console.log(response.data)
                setSearchResults(response.data);
            })
            .catch(error => {
                console.error('Error al obtener datos:', error);
            });
    };

    const idItem = (id) => {
        setShowInformacion(true)
        setValueSearch(id)
    }

    

    return(
        <div className="flex flex-col justify-center w-full">
            <div className="relative pt-0 pb-0 pl-[400px] pr-[400px] w-full">
                <div className="overflow-hidden z-0 rounded-full relative p-1">
                <div className="relative flex z-50  rounded-full">
                    <input type="text" onChange={(e) => setSearchTask(e.target.value)} placeholder="Enter your search here" className="rounded-full flex-1 px-6 py-4 text-gray-700 focus:outline-none"/>
                    <button onClick={handleSubmit} className="bg-indigo-500 bg-opacity-70 text-white rounded-full font-semibold px-8 py-4 hover:bg-indigo-400 focus:bg-indigo-600 focus:outline-none">Search</button>
                </div>
                <div className="glow glow-1 z-10 bg-opacity-30 bg-pink-400 absolute"></div>
                <div className="glow glow-2 z-20 bg-opacity-30 bg-purple-400 absolute"></div>
                <div className="glow glow-3 z-30 bg-opacity-30 bg-yellow-400 absolute"></div>
                <div className="glow glow-4 z-40 bg-opacity-30 bg-blue-400 absolute"></div>
                </div>
            </div>
            <div className='flex w-full justify-center items-center flex-col'>
                <div className='flex w-[28%] bg-slate-950 rounded-2xl z-20 h-full flex-col p-2'>
                    {searchResults.map(result => (
                            <TasItemSearch key={result.idTask} tittle={result.nameTask} status={result.status.nameStatus} IdTask={() => idItem(result.idTask)}/>
                    ))}
                </div>
            </div>
        </div>
    )
}

