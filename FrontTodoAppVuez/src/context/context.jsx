import React, { createContext, useState, useContext, useEffect } from "react";
import axios from "axios";

export const contextProp = createContext();

export const ContextProvider = ({ children }) => {
const [changeForm, setChangeForm] = useState(false);
const [valueDialog, setValueDialog] = useState(false);
const [responseData, setResponseData] = useState([]);
const [ statusUser, setStatusUser ] = useState(false);



  return (
    <contextProp.Provider value={{changeForm, setChangeForm, responseData, setResponseData, valueDialog, setValueDialog,statusUser, setStatusUser }}>
      {children}
    </contextProp.Provider>
  );
};