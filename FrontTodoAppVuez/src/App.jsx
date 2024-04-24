import { useContext } from 'react'
import './App.css'
import {Header} from './components/Header'
import { RegisterForm, LoginForm } from './components/Login'
import DragAndDrop from './components/PrincipalCarContext'
import { PrincipalCard } from './components/PrincipalCard'
import { contextProp } from './context/context'

function App() {
  const {changeForm} = useContext(contextProp);

  return (
    <main className='flex flex-1 h-screen w-full bg-[#0E0F12] flex-col xl:w-[1280px]'>
      <div className='flex flex-row flex-1 p-4 justify-between'>
        <DragAndDrop /> 
      </div>
      
      <div  className='flex flex-1 h-screen w-full bg-[#0E0F12] flex-col xl:w-[1280px] items-center justify-center'>
        { changeForm ?(<LoginForm/> ):(<RegisterForm />)
          

        }
      </div>
    </main>
  )
}

export default App
