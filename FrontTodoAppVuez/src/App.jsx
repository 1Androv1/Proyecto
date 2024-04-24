import { useContext, useEffect, useState } from 'react'
import './App.css'
import {Header} from './components/Header'
import { RegisterForm, LoginForm } from './components/Login'
import DragAndDrop from './components/PrincipalCarContext'
import { contextProp } from './context/context'
import { CreateTaskDialog, EditTaskDialog, ShowInformation } from './components/CreateTask'
import { Toaster } from 'react-hot-toast';
import { Footer } from './components/Footer'

function App() {
  const {changeForm, statusUser, setValueDialog, setStatusUser} = useContext(contextProp);

  const handleOpen = () => {
    console.log("si entro")
    setValueDialog(true);
  };

  const handleClose = () => {
    console.log("si entro")
    setValueDialog(false);
  };

  useEffect(()=>{
    console.log(statusUser)
    if(statusUser == true){
      localStorage.setItem('statusUser', true);
      setStatusUser(true)
      console.log("se almacena "+statusUser)
    }else if(statusUser == false){
      localStorage.setItem('statusUser', false);
      console.log("se almacena "+statusUser)
      setStatusUser(false)
      localStorage.clear();
      localStorage.removeItem('statusUser')
    }

  },[statusUser])

  return (
    <main className='flex flex-1 h-screen w-full bg-[#0E0F12] flex-col xl:w-[1280px] overflow-hidden box-content'>
      {statusUser ? (
      <>
        <Header />
          <div className='flex flex-row flex-1 p-4 justify-between'>
            <DragAndDrop onPressOpenDialog={handleOpen}/> 
          </div>
        <CreateTaskDialog onPress={handleClose}/>
        <EditTaskDialog onPress={handleClose} />
        <ShowInformation onPress={handleClose} />
        <Footer />
      </>
      ):(
        <div  className='flex flex-1 h-screen w-full bg-[#0E0F12] flex-col xl:w-[1280px] items-center justify-center'>
          { changeForm ?(<RegisterForm /> ):(<LoginForm/>) }
        </div> 
      )}
      <div><Toaster/></div>
    </main>
  )
}

export default App
