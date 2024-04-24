import React, { createContext, useState, useContext, useEffect } from "react";
import axios from "axios";

export const contextProp = createContext();

export const ContextProvider = ({ children }) => {
const [changeForm, setChangeForm] = useState(false);
const [valueDialog, setValueDialog] = useState(false);
const [editDialog, setEditDialog] = useState(false);
const [responseData, setResponseData] = useState([]);
<<<<<<< HEAD
const [statusUser, setStatusUser ] = useState(false);
const [datatask, setDataTask] = useState([]);

  return (
    <contextProp.Provider value={{changeForm, setChangeForm, responseData, setResponseData, valueDialog, setValueDialog,statusUser, setStatusUser, datatask, setDataTask }}>
=======
const [ statusUser, setStatusUser ] = useState(true);
const [infoEdit, setInfoEdit ] = useState([])




  return (
    <contextProp.Provider value={{changeForm, setChangeForm, responseData, setResponseData, valueDialog, setValueDialog,statusUser, setStatusUser, editDialog, setEditDialog, infoEdit, setInfoEdit  }}>
>>>>>>> 6090a7713a901ffd5b193056159638d9c621f332
      {children}
    </contextProp.Provider>
  );
};