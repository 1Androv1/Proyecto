import './App.css'
import {Header} from './components/Header'
import { PrincipalCard } from './components/PrincipalCard'

function App() {

  return (
    <main className='flex flex-1 h-screen w-full bg-[#0E0F12] flex-col xl:w-[1280px]'>
      <Header />
      <div className='flex flex-row flex-1 p-4 justify-evenly'>
        <PrincipalCard Tittle={"TO-DO"} />
        <PrincipalCard Tittle={"IN-PROOGRESS"} />
        <PrincipalCard Tittle={"COMPLETED"} />
      </div>
     
    </main>
  )
}

export default App
