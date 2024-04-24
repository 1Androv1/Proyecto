import './App.css'
import {Header} from './components/Header'
import { RegisterForm, LoginForm } from './components/Login'
import DragAndDrop from './components/PrincipalCarContext'
import { PrincipalCard } from './components/PrincipalCard'

function App() {

  return (
    <main className='flex flex-1 h-screen w-full bg-[#0E0F12] flex-col xl:w-[1280px]'>
     {/*  <Header />
      <div className='flex flex-row flex-1 p-4 justify-between'>
        <DragAndDrop /> 
      </div>
      */}

      <div  className='flex flex-1 h-screen w-full bg-[#0E0F12] flex-col xl:w-[1280px] items-center justify-center'>
    <LoginForm/> 
      {/*  <RegisterForm />*/}
      </div>
      
     
    </main>
  )
}

export default App
