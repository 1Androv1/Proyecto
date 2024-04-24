import React, { createContext, useState, useContext } from "react";
import { ApiLocalHost } from "../coneccions/api";
import axios from "axios";

export const contextProp = createContext();

export const ContextProvider = ({ children }) => {
    axios.get(ApiLocalHost)
    .then(response => {
      // Manejar la respuesta exitosa
      console.log('Datos recibidos:', response.data);
    })
    .catch(error => {
      // Manejar el error
      console.error('Error al obtener datos:', error);
    });

  return (
    <contextProp.Provider value={{}}>
      {children}
    </contextProp.Provider>
  );
};