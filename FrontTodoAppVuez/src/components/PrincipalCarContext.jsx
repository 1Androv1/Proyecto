import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom";
import { TaskItemCompleted, TaskItemInProgress, TaskItemToDo } from "./TaskItem";
import axios from "axios";
import { GetAllTask, changeStatus } from "../coneccions/api";

const DragAndDrop = ({onPressOpenDialog}) => {
    const [ datatask, setDataTask ] = useState([])
    const [ dropinfo, setDropInfo ] = useState([])


    useEffect(()=> {
        axios.get(GetAllTask)
        .then(response => {
            if (response && response.data) {
                const getTasks = response.data;
                setDataTask(getTasks);
            } else {
                alert("La respuesta no contiene datos.");
            }
        })
        .catch(error => {
          // Manejar el error
          console.error('Error al obtener datos:', error);
        });
    },[])


    const getList = (list) => {
        return datatask.filter(item => item.statusId === list)
    }

    const startDrag = (evt, item) => {
        evt.dataTransfer.setData('itemID', item.idTask)
        console.log(item);
    }

    const draggingOver = (evt) => {
        evt.preventDefault();
    }

    const onDrop = (evt, list) => {
        const itemID = evt.dataTransfer.getData('itemID');
        const item = datatask.find(item => item.idTask == itemID);
        item.statusId = list;
        setDropInfo({ idTask: itemID, statusId: list });
    
        const newState = datatask.map(task => {
            if(task.idTask === itemID) return item;
            return task
        });
    
        setDataTask(newState);
    }

    useEffect(()=>{
        if(dropinfo){
            console.log(dropinfo)
            axios.post(changeStatus, dropinfo, {
            headers: {
                'Content-Type': 'application/json'
            }
            })
            .then(response => {
                console.log(response)
            })
            .catch(error => {
              // Manejar el error
            console.error('Error al obtener datos:', error);
            });
        }
            
    },[dropinfo])


    return (
        <main className='flex rounded-xl justify-around relative w-full'>
            <section className='flex w-80 rounded-xl section-with-gradient relative'>
                <header className='flex justify-center items-center w-full absolute top-0 h-10 border-solid border-b border-gray-500'>
                    <h3 className='text-2xl text-white font-extrabold uppercase'>TO-DO</h3>
                </header>
                <div className='dd-zone' droppable="true" onDragOver={draggingOver} onDrop={(evt) => onDrop(evt, 1)}>
                    {getList(1).map(item => (
                            <div className='containt-father flex flex-row justify-center items-center w-11/12' key={item.idTask} draggable onDragStart={(evt) => startDrag(evt, item)}>
                                <TaskItemToDo tittle={item.nameTask}/>
                            </div>
                    ))}
                    <button onClick={onPressOpenDialog} className='outline-none bg-transparent focus:outline-none border-none justify-center items-center flex-row'>
                        <strong className='text-2xl text-blue-900'>+</strong>
                        <span className='text-white font-bold capitalize text-sm mb-3'>Add Task</span>
                    </button>
                </div>
            </section>

            <section className='flex w-80 rounded-xl section-with-gradient relative'>
                <header className='flex justify-center items-center w-full absolute top-0 h-10 border-solid border-b border-gray-500'>
                    <h3 className='text-2xl text-white font-extrabold uppercase'>in progress</h3>
                </header>
                <div className='dd-zone' droppable="true" onDragOver={draggingOver} onDrop={(evt) => onDrop(evt, 2)}>
                    {getList(2).map(item => (
                        <div className='containt-father flex flex-row justify-center items-center w-11/12' key={item.idTask} draggable onDragStart={(evt) => startDrag(evt, item)}>
                            <TaskItemInProgress tittle={item.nameTask}/>
                        </div>
                    ))}
                </div>
            </section>


            <section className='flex w-80 rounded-xl section-with-gradient relative'>
                <header className='flex justify-center items-center w-full absolute top-0 h-10 border-solid border-b border-gray-500'>
                    <h3 className='text-2xl text-white font-extrabold uppercase'>completed</h3>
                </header>
                <div className='dd-zone' droppable="true" onDragOver={draggingOver} onDrop={(evt) => onDrop(evt, 3)}>
                    {getList(3).map(item => (
                        <div className='containt-father flex flex-row justify-center items-center w-11/12' key={item.idTask} draggable onDragStart={(evt) => startDrag(evt, item)}>
                            <TaskItemCompleted tittle={item.nameTask}/>
                        </div>
                    ))}
                </div>
            </section>

        </main>
    )
}

export default DragAndDrop;     