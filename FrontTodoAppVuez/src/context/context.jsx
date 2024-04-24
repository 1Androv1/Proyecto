import React, { createContext, useState, useContext, useEffect } from "react";
import axios from "axios";

export const contextProp = createContext();

export const ContextProvider = ({ children }) => {
const [changeForm, setChangeForm] = useState(false);
const [valueDialog, setValueDialog] = useState(false);
const [editDialog, setEditDialog] = useState(false);
const [responseData, setResponseData] = useState([]);
const [statusUser, setStatusUser ] = useState(false);
const [datatask, setDataTask] = useState([]);
const [infoEdit, setInfoEdit ] = useState([]);
const [info, setInfo ] = useState([]);
const [valueSearch, setValueSearch ] = useState([]);


const [ showinformation, setShowInformacion ] = useState(false)

  return (
    <contextProp.Provider value={{changeForm, setChangeForm, responseData, setResponseData, valueDialog, setValueDialog,statusUser, setStatusUser, editDialog, setEditDialog, infoEdit, setInfoEdit, showinformation, setShowInformacion, info, setInfo, valueSearch, setValueSearch  }}>
      {children}
    </contextProp.Provider>
  );
};