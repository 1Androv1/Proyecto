import React, { useState } from "react";
import ReactDOM from "react-dom";
import { TaskItemCompleted, TaskItemInProgress, TaskItemToDo } from "./TaskItem";

const DragAndDrop = () => {
    const [tasks, setTasks] = useState([
        { 
            id: 1,
            title: 'Deivid Tarea Con Texto Muy Largo largo larguisisisisisimo',
            body: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit ipsum dolor.',
            list: 1
        },
        { 
            id: 2,
            title: 'Tarea 2',
            body: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit ipsum dolor.',
            list: 1
        },
        { 
            id: 3,
            title: 'Tarea 3',
            body: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit ipsum dolor.',
            list: 3
        },
        { 
            id: 4,
            title: 'Tarea 4',
            body: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit ipsum dolor.',
            list: 2
        },
        { 
            id: 5,
            title: 'Tarea 5',
            body: 'Lorem, ipsum dolor sit amet consectetur adipisicing elit ipsum dolor.',
            list: 2
        },
    ]);

    const getList = (list) => {
        return tasks.filter(item => item.list === list)
    }

    const startDrag = (evt, item) => {
        evt.dataTransfer.setData('itemID', item.id)
        console.log(item);
    }

    const draggingOver = (evt) => {
        evt.preventDefault();
    }

    const onDrop = (evt, list) => {
        const itemID = evt.dataTransfer.getData('itemID');
        const item = tasks.find(item => item.id == itemID);
        item.list = list;

        const newState = tasks.map(task => {
            if(task.id === itemID) return item;
            return task
        })

        setTasks(newState);
    }

    return (
        <main className='flex rounded-xl justify-around relative w-full'>
            <section className='flex w-80 rounded-xl section-with-gradient relative'>
                <header className='flex justify-center items-center w-full absolute top-0 h-10 border-solid border-b border-gray-500'>
                    <h3 className='text-2xl text-white font-extrabold uppercase'>TO-DO</h3>
                </header>
                <div className='dd-zone' droppable="true" onDragOver={draggingOver} onDrop={(evt) => onDrop(evt, 1)}>
                    {getList(1).map(item => (
                            <div className='containt-father flex flex-row justify-center items-center w-11/12' key={item.id} draggable onDragStart={(evt) => startDrag(evt, item)}>
                                <TaskItemToDo item={item}/>
                            </div>
                    ))}
                    <button className='outline-none bg-transparent focus:outline-none border-none justify-center items-center flex-row'>
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
                        <div className='containt-father flex flex-row justify-center items-center w-11/12' key={item.id} draggable onDragStart={(evt) => startDrag(evt, item)}>
                            <TaskItemInProgress item={item}/>
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
                        <div className='containt-father flex flex-row justify-center items-center w-11/12' key={item.id} draggable onDragStart={(evt) => startDrag(evt, item)}>
                            <TaskItemCompleted item={item}/>
                        </div>
                    ))}
                </div>
            </section>

        </main>
    )
}

export default DragAndDrop;     