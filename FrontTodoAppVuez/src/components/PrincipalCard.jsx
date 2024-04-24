export const PrincipalCard = ({Tittle}) => {
    return (
        <main className='flex w-80 rounded-xl section-with-gradient relative'>
            <header className='flex justify-center items-center w-full absolute top-0 h-10 border-solid border-b border-gray-500'>
                <h3 className='text-2xl text-white font-extrabold uppercase'>{Tittle}</h3>
            </header>
            <section className='flex w-full bg-slate-100 mt-11 p-2 flex-col gap-2'>
                <div className='w-full h-[50px]'></div>
                <div className='w-full h-[50px]'></div>
                <div className='w-full h-[50px]'></div>
                <div className='w-full h-[50px]'></div>
                <button>
                    + ADD TASK
                </button>
            </section>
        </main>
    )
  }
  