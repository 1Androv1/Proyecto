import React, { createContext, useState, useContext } from "react";
import axios from "axios";

export const contextProp = createContext();

export const ContextProvider = ({ children }) => {

  return (
    <contextProp.Provider value={{}}>
      {children}
    </contextProp.Provider>
  );
};