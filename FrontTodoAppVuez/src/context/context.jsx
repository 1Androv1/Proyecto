import React, { createContext, useState, useContext } from "react";
import axios from "axios";

export const contextProp = createContext();

export const ContextProvider = ({ children }) => {
const [changeForm, setChangeForm] = useState(false);


  return (
    <contextProp.Provider value={{changeForm, setChangeForm}}>
      {children}
    </contextProp.Provider>
  );
};