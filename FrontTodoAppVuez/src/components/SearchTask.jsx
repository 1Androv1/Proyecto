import './styles.css'; 

export const SearchTask = () => {
    return(
        <div class="flex flex-col justify-center w-full">
            <div class="relative pt-0 pb-0 pl-[400px] pr-[400px] w-full">
                <div class="overflow-hidden z-0 rounded-full relative p-1">
                <form role="form" class="relative flex z-50  rounded-full">
                    <input type="text" placeholder="enter your search here" class="rounded-full flex-1 px-6 py-4 text-gray-700 focus:outline-none"/>
                    <button class="bg-indigo-500 bg-opacity-70 text-white rounded-full font-semibold px-8 py-4 hover:bg-indigo-400 focus:bg-indigo-600 focus:outline-none">Search</button>
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

