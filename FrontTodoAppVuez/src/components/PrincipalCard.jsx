export const PrincipalCard = ({Tittle}) => {
    return (
        <section className='flex w-80 rounded-xl section-with-gradient relative'>
            <header className='flex justify-center items-center w-full absolute top-0 h-10 border-solid border-b border-gray-500'>
                <h3 className='text-2xl text-white font-extrabold uppercase'>{Tittle}</h3>
            </header>
        </section>
    )
  }
  