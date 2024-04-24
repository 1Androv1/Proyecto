import { useContext, useState } from 'react'
import './App.css'
import {Header} from './components/Header'
import { RegisterForm, LoginForm } from './components/Login'
import DragAndDrop from './components/PrincipalCarContext'
import { PrincipalCard } from './components/PrincipalCard'
import { contextProp } from './context/context'
import { CreateTaskDialog } from './components/CreateTask'

function App() {
  const {changeForm} = useContext(contextProp);
  const { setValueDialog } = useContext(contextProp)

  const handleOpen = () => {
    console.log("si entro")
    setValueDialog(true);
  };

  const handleClose = () => {
    console.log("si entro")
    setValueDialog(false);
  };


  return (
    <main className='flex flex-1 h-screen w-full bg-[#0E0F12] flex-col xl:w-[1280px] overflow-hidden box-content'>
      <Header />
      <div className='flex flex-row flex-1 p-4 justify-between'>
        <DragAndDrop onPressOpenDialog={handleOpen}/> 
      </div>
      
       <div  className='flex flex-1 h-screen w-full bg-[#0E0F12] flex-col xl:w-[1280px] items-center justify-center'>
        { changeForm ?(<LoginForm/> ):(<RegisterForm />)
          

        }
      </div> 

      <CreateTaskDialog onPress={handleClose}/>
    </main>
  )
}

export default App
