import './styles.css'; 
import { filterTask } from "../coneccions/api";
import axios from 'axios';
import { useState } from 'react';

export const SearchTask = () => {
    const [searchTask, setSearchTask] = useState('');

    const handleSubmit = () => {
        const filtro = searchTask;

        axios.get(filterTask + filtro)
            .then(response => {
                console.log(response.data);
            })
            .catch(error => {
                console.error('Error al obtener datos:', error);
            });
    };

    return(
        <div class="flex flex-col justify-center w-full">
            <div class="relative pt-0 pb-0 pl-[400px] pr-[400px] w-full">
                <div class="overflow-hidden z-0 rounded-full relative p-1">
                <form role="form" class="relative flex z-50  rounded-full">
                    <input type="text" onChange={(e) => setSearchTask(e.target.value)} placeholder="enter your search here" class="rounded-full flex-1 px-6 py-4 text-gray-700 focus:outline-none"/>
                    <button onClick={() => handleSubmit()} class="bg-indigo-500 bg-opacity-70 text-white rounded-full font-semibold px-8 py-4 hover:bg-indigo-400 focus:bg-indigo-600 focus:outline-none">Search</button>
                </form>
                <div class="glow glow-1 z-10 bg-opacity-30 bg-pink-400 absolute"></div>
                <div class="glow glow-2 z-20 bg-opacity-30 bg-purple-400 absolute"></div>
                <div class="glow glow-3 z-30 bg-opacity-30 bg-yellow-400 absolute"></div>
                <div class="glow glow-4 z-40 bg-opacity-30 bg-blue-400 absolute"></div>
                </div>
            </div>
        </div>
    )
}

