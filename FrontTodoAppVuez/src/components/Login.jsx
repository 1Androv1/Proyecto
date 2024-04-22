import React, { useState } from 'react';

export const LoginForm = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        // Aquí puedes realizar las acciones necesarias, como enviar los datos a un servidor
        console.log('Email:', email);
        console.log('Password:', password);
    };

    return (
        <form className="form_container max-w-[400px]" onSubmit={handleSubmit}>
            <div className="title_container" style={{width: '100%'}}>
                <p className="title left-0" 
                style={{    
                    textAlign: 'left',
                    justifyContent: 'left',
                    alignItems: 'center',
                    width: '100%',
                }}>Login</p>
                <span className="subtitle">Get started with our app.</span>
            </div>
            <br/>
            <div className="input_container">
                <label className="input_label" htmlFor="email_field">Email</label>
                <svg fill="none" viewBox="0 0 24 24" height="24" width="24" xmlns="http://www.w3.org/2000/svg" className="icon">
                    <path d="M12.9999 12.9998C14.9881 12.9998 16.5999 11.388 16.5999 9.3998C16.5999 7.41158 14.9881 5.7998 12.9999 5.7998C11.0117 5.7998 9.3999 7.41158 9.3999 9.3998C9.3999 11.388 11.0117 12.9998 12.9999 12.9998Z" stroke="#1C274C" strokeWidth="1.5"/>
                    <path d="M20.1629 22.5996C19.972 19.1298 18.9096 16.5996 12.9999 16.5996C7.09025 16.5996 6.02789 19.1298 5.83691 22.5996" stroke="#1C274C" strokeWidth="1.5" strokeLinecap="round"/>
                    <path d="M7 2.60538C8.76504 1.58436 10.8143 1 13 1C19.6274 1 25 6.37258 25 13C25 19.6274 19.6274 25 13 25C6.37258 25 1 19.6274 1 13C1 10.8143 1.58436 8.76504 2.60538 7" stroke="#1C274C" strokeWidth="1.5" strokeLinecap="round"/>
                </svg>
                <input 
                    placeholder="name@mail.com" 
                    title="Input title" 
                    name="input-name" 
                    type="text" 
                    className="input_field bg-slate-200" 
                    id="email_field" 
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
            </div>
            <div className="input_container">
                <label className="input_label" htmlFor="password_field">Password</label>
                <svg fill="none" viewBox="0 0 24 24" height="24" width="24" xmlns="http://www.w3.org/2000/svg" className="icon">
                    <path d="M18 11.0041C17.4166 9.91704 16.273 9.15775 14.9519 9.0993C13.477 9.03404 11.9788 9 10.329 9C8.67911 9 7.18091 9.03404 5.70604 9.0993C3.95328 9.17685 2.51295 10.4881 2.27882 12.1618C2.12602 13.2541 2 14.3734 2 15.5134C2 16.6534 2.12602 17.7727 2.27882 18.865C2.51295 20.5387 3.95328 21.8499 5.70604 21.9275C6.42013 21.9591 7.26041 21.9834 8 22" stroke="#1C274C" strokeWidth="1.5" strokeLinecap="round"/>
                    <path d="M6 9V6.5C6 4.01472 8.01472 2 10.5 2C12.9853 2 15 4.01472 15 6.5V9" stroke="#1C274C" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"/>
                    <path d="M21.4194 16.477C21.7459 16.7975 22.2704 16.7927 22.5909 16.4663C22.9114 16.1398 22.9066 15.6153 22.5802 15.2948L21.4194 16.477ZM18.2377 18.039C18.5641 18.3596 19.0886 18.3548 19.4092 18.0283C19.7297 17.7019 19.7249 17.1774 19.3985 16.8568L18.2377 18.039ZM14.2601 20.7622C13.7037 21.3085 12.7955 21.3085 12.2392 20.7622L11.0784 21.9444C12.2792 23.1235 14.22 23.1235 15.4209 21.9444L14.2601 20.7622ZM12.2392 20.7622C11.6912 20.2242 11.6912 19.3583 12.2392 18.8203L11.0784 17.6381C9.86905 18.8255 9.86905 20.757 11.0784 21.9444L12.2392 20.7622ZM12.2392 18.8203C12.7955 18.274 13.7037 18.274 14.2601 18.8203L15.4209 17.6381C14.22 16.459 12.2792 16.459 11.0784 17.6381L12.2392 18.8203ZM14.2601 18.8203C14.808 19.3583 14.808 20.2242 14.2601 20.7622L15.4209 21.9444C16.6302 20.757 16.6302 18.8255 15.4209 17.6381L14.2601 18.8203ZM20.624 15.6959L21.4194 16.477L22.5802 15.2948L21.7848 14.5137L20.624 15.6959ZM15.4209 18.8203L17.8076 16.477L16.6468 15.2947L14.2601 17.638L15.4209 18.8203ZM17.8076 16.477L18.603 15.6959L17.4422 14.5137L16.6468 15.2947L17.8076 16.477ZM16.6468 16.477L18.2377 18.039L19.3985 16.8568L17.8076 15.2948L16.6468 16.477ZM21.7848 14.5137C21.4264 14.1619 21.0996 13.8386 20.7991 13.6134C20.4789 13.3735 20.0958 13.1719 19.6135 13.1719V14.8287C19.6143 14.8287 19.6188 14.8276 19.6393 14.836C19.6661 14.8469 19.7181 14.8738 19.8058 14.9394C19.9967 15.0825 20.2324 15.3115 20.624 15.6959L21.7848 14.5137ZM18.603 15.6959C18.9946 15.3115 19.2303 15.0825 19.4213 14.9394C19.5089 14.8738 19.5609 14.8469 19.5877 14.836C19.6082 14.8276 19.6127 14.8287 19.6135 14.8287V13.1719C19.1312 13.1719 18.7481 13.3735 18.4279 13.6134C18.1274 13.8386 17.8006 14.1619 17.4422 14.5137L18.603 15.6959Z" fill="#1C274C"/>
                </svg>
                <input 
                    placeholder="Password" 
                    title="Input title" 
                    name="input-name" 
                    type="password" 
                    className="input_field bg-slate-200" 
                    id="password_field" 
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
            </div>
            <button title="Sign In" type="submit" className="sign-in_btn">
                <span>Sign In</span>
            </button>
            <p className="signin w-2/3">Without an account, does my dog count? create one here <a href="#">Sign up</a></p>
        </form>
    );
};

export const RegisterForm = () => {
        const [formData, setFormData] = useState({
            firstname: '',
            lastname: '',
            email: '',
            password: '',
            confirmPassword: ''
        });
    
        const handleChange = (e) => {
            setFormData({
                ...formData,
                [e.target.name]: e.target.value
            });
        };
    
        const handleSubmit = (e) => {
            e.preventDefault();
            // Aquí puedes agregar la lógica para enviar los datos del formulario a tu backend
            console.log(formData);
        };
    
        return (
            <form className="form max-w-[400px]" onSubmit={handleSubmit}>
                <p className="title">Register</p>
                <p className="message">Signup now and get full access to our app.</p>
                <div className="flex">
                    <label>
                        <input
                            className="input bg-slate-200"
                            type="text"
                            placeholder=""
                            name="firstname"
                            value={formData.firstname}
                            onChange={handleChange}
                            required
                        />
                        <span>Firstname</span>
                    </label>
    
                    <label>
                        <input
                            className="input bg-slate-200"
                            type="text"
                            placeholder=""
                            name="lastname"
                            value={formData.lastname}
                            onChange={handleChange}
                            required
                        />
                        <span>Lastname</span>
                    </label>
                </div>
    
                <label>
                    <input
                        className="input bg-slate-200"
                        type="email"
                        placeholder=""
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        required
                    />
                    <span>Email</span>
                </label>
    
                <label>
                    <input
                        className="input bg-slate-200"
                        type="password"
                        placeholder=""
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        required
                    />
                    <span>Password</span>
                </label>
                <label>
                    <input
                        className="input bg-slate-200"
                        type="password"
                        placeholder=""
                        name="confirmPassword"
                        value={formData.confirmPassword}
                        onChange={handleChange}
                        required
                    />
                    <span>Confirm password</span>
                </label>
                <button className="submit" type="submit">Submit</button>
                <p className="signin">Already have an account? <a href="#">Sign in</a></p>
            </form>
        );
};

