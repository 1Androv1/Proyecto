
export const TaskItemToDo = ({tittle}) => {
    return (
        <>
            <img className='w-4 h-4 opacity-0 mr-1' src="src/assets/DragIcon.svg" alt="Drag" style={{ pointerEvents: 'none', userSelect: 'none' }} />
            <div className='w-11/12 contenedor-opacidad rounded-md'>
                <div className='flex w-full h-full flex-row p-1'>
                    <div className="flex flex-1 items-center text-ellipsis whitespace-nowrap">
                        <strong className='text-white text-lg font-bold ml-2 '>{tittle}</strong>
                    </div>
                    <div className="flex justify-end gap-2 items-center pl-2 pr-2">
                        <button className="h-full w-4 flex items-center justify-center p-0 mr-0 outline-none border-none bg-transparent focus:outline-none" style={{ overflow: 'visible' }}>
                            <svg width="20" height="26" viewBox="0 0 40 46" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M22.3483 10.9869C23.1159 10.0294 22.9618 8.63116 22.0041 7.86377C21.0467 7.09641 19.6485 7.25048 18.8812 8.20796L22.3483 10.9869ZM3.14302 31.3972L4.82571 32.8479C4.84307 32.8277 4.86004 32.8073 4.87666 32.7866L3.14302 31.3972ZM2.63647 32.6355L0.419051 32.4906L0.417096 32.5327L2.63647 32.6355ZM2.22174 41.5906L0.00237196 41.4878C-0.00272323 41.598 0.00038721 41.7085 0.0117329 41.8184L2.22174 41.5906ZM4.55309 43.6257L4.62572 45.8463C4.7739 45.8412 4.92119 45.8217 5.06545 45.7873L4.55309 43.6257ZM13.44 41.5195L13.9525 43.6814L13.9869 43.6728L13.44 41.5195ZM14.5805 40.7967L16.2945 42.2106L16.3138 42.1866L14.5805 40.7967ZM34.2062 19.8744C34.9738 18.917 34.82 17.5188 33.8629 16.7511C32.9058 15.9835 31.5072 16.1372 30.7397 17.0946L34.2062 19.8744ZM18.8904 8.20737C18.1229 9.16459 18.2763 10.5629 19.2338 11.3306C20.1909 12.0983 21.5891 11.9447 22.3569 10.9875L18.8904 8.20737ZM25.3278 3.73202L27.0611 5.12209C27.0901 5.08568 27.1183 5.04835 27.1452 5.01017L25.3278 3.73202ZM30.1535 2.78408L31.5748 1.07647C31.504 1.01758 31.4296 0.963166 31.3523 0.913488L30.1535 2.78408ZM36.7802 8.29992L38.3526 6.73036C38.3043 6.68204 38.2539 6.63601 38.2015 6.59232L36.7802 8.29992ZM36.7535 13.1522L35.1983 11.5655C35.1355 11.6272 35.0762 11.6926 35.0208 11.7614L36.7535 13.1522ZM30.7397 17.0946C29.9716 18.0514 30.1253 19.4487 31.0821 20.2169C32.039 20.985 33.4381 20.8312 34.2062 19.8744L30.7397 17.0946ZM22.8208 9.26818C22.6389 8.0547 21.5079 7.21837 20.2946 7.40023C19.0809 7.58206 18.2446 8.71319 18.4265 9.92667L22.8208 9.26818ZM32.7722 20.6858C33.9879 20.5208 34.8396 19.401 34.6746 18.1853C34.5093 16.9694 33.3898 16.1177 32.1738 16.2829L32.7722 20.6858ZM18.8812 8.20796L1.40938 30.0076L4.87666 32.7866L22.3483 10.9869L18.8812 8.20796ZM1.46034 29.9463C0.84607 30.6587 0.480283 31.5519 0.419051 32.4906L4.8535 32.7801C4.85187 32.8049 4.84212 32.8289 4.82571 32.8479L1.46034 29.9463ZM0.417096 32.5327L0.00237196 41.4878L4.44111 41.6934L4.85584 32.7383L0.417096 32.5327ZM0.0117329 41.8184C0.253666 44.1642 2.26878 45.9233 4.62572 45.8463L4.48045 41.4051C4.47097 41.4054 4.46632 41.404 4.4633 41.4028C4.45906 41.4013 4.45347 41.3983 4.44775 41.3933C4.442 41.3883 4.4383 41.3832 4.43619 41.3794C4.43468 41.3764 4.43273 41.372 4.43175 41.3625L0.0117329 41.8184ZM5.06545 45.7873L13.9525 43.6814L12.9276 39.3576L4.04072 41.4638L5.06545 45.7873ZM13.9869 43.6728C14.8919 43.4429 15.7003 42.931 16.2945 42.2106L12.8665 39.3828C12.8737 39.3745 12.8828 39.3685 12.8932 39.3659L13.9869 43.6728ZM16.3138 42.1866L34.2062 19.8744L30.7397 17.0946L12.8473 39.4068L16.3138 42.1866ZM22.3569 10.9875L27.0611 5.12209L23.5946 2.34198L18.8904 8.20737L22.3569 10.9875ZM27.1452 5.01017C27.5558 4.42624 28.3536 4.2695 28.9546 4.65469L31.3523 0.913488C28.7475 -0.755661 25.2902 -0.0765195 23.5105 2.45389L27.1452 5.01017ZM28.7321 4.49167L35.3588 10.0075L38.2015 6.59232L31.5748 1.07647L28.7321 4.49167ZM35.2078 9.8695C35.4326 10.0949 35.5582 10.4009 35.5564 10.7194L39.9999 10.7438C40.0082 9.23983 39.4152 7.79487 38.3526 6.73036L35.2078 9.8695ZM35.5564 10.7194C35.555 11.0379 35.4258 11.3425 35.1983 11.5655L38.3087 14.739C39.3829 13.6862 39.9916 12.2478 39.9999 10.7438L35.5564 10.7194ZM35.0208 11.7614L30.7397 17.0946L34.2062 19.8744L38.4862 14.5431L35.0208 11.7614ZM18.4265 9.92667C19.4613 16.8327 25.8525 21.626 32.7722 20.6858L32.1738 16.2829C27.6624 16.8959 23.4956 13.7707 22.8208 9.26818L18.4265 9.92667Z" fill="white"/>
                            </svg>
                        </button>
                        <button className="h-full w-4 flex items-center justify-center p-0 mr-0 outline-none border-none bg-transparent focus:outline-none" style={{ overflow: 'visible' }}>
                            <svg width="20" height="26" viewBox="0 0 44 46" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M42 9.05859H2" stroke="#B82323" strokeWidth="3" strokeLinecap="round"/>
                                <path d="M16.1177 20.8232L17.2941 32.5879" stroke="#B82323" strokeWidth="3" strokeLinecap="round"/>
                                <path d="M27.882 20.8232L26.7056 32.5879" stroke="#B82323" strokeWidth="3" strokeLinecap="round"/>
                                <path d="M9.05859 9.05878C9.19008 9.05878 9.25582 9.05878 9.31542 9.05728C11.2529 9.00817 12.9621 7.77622 13.6214 5.95367C13.6417 5.8976 13.6625 5.83525 13.7041 5.7105L13.9325 5.02518C14.1275 4.44017 14.225 4.14766 14.3543 3.89928C14.8703 2.90839 15.825 2.22033 16.9282 2.04416C17.2047 2 17.5131 2 18.1298 2H25.8696C26.4863 2 26.7947 2 27.0712 2.04416C28.1745 2.22033 29.1291 2.90839 29.6451 3.89928C29.7745 4.14766 29.8719 4.44017 30.0669 5.02518L30.2954 5.7105C30.3368 5.83508 30.3578 5.89765 30.378 5.95367C31.0373 7.77622 32.7465 9.00817 34.6841 9.05728C34.7436 9.05878 34.8093 9.05878 34.9408 9.05878" stroke="#B82323" strokeWidth="3"/>
                                <path d="M36.9969 31.1745C36.5804 37.4213 36.3722 40.5448 34.3369 42.4488C32.3016 44.353 29.1713 44.353 22.9106 44.353H21.0909C14.8302 44.353 11.6999 44.353 9.66455 42.4488C7.62925 40.5448 7.42101 37.4213 7.00457 31.1745L5.92236 14.9414M38.079 14.9414L37.6084 22.0002" stroke="#B82323" strokeWidth="3" strokeLinecap="round"/>
                            </svg>
                        </button>
                    </div>
                </div>
            </div>
        </>
    );

}


export const TaskItemInProgress = ({tittle}) => {
    return (
        <>
            <img className='w-4 h-4 opacity-0 mr-1' src="src/assets/DragIcon.svg" alt="Drag" style={{ pointerEvents: 'none', userSelect: 'none' }} />
            <div className='w-11/12 contenedor-opacidad rounded-md'>
                <div className='flex w-full h-full flex-row p-1'>
                    <div className="flex flex-1 items-center text-ellipsis whitespace-nowrap">
                        <strong className='text-white text-lg font-bold ml-2 '>{tittle}</strong>
                    </div>
                    <div className="flex justify-end gap-2 items-center pl-2 pr-2">
                        <span>00:00:00</span>
                        <button disabled className="h-full w-4 flex items-center justify-center p-0 mr-0 outline-none border-none bg-transparent focus:outline-none" style={{ overflow: 'visible' }}>
                            <svg width="20" height="26" viewBox="0 0 44 44" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M22 13.1113V22.0002L28.6667 28.6669" stroke="#A4D934" strokeWidth="3" strokeLinecap="round"/>
                                <path d="M22 42C33.0457 42 42 33.0457 42 22C42 10.9543 33.0457 2 22 2C10.9543 2 2 10.9543 2 22C2 33.0457 10.9543 42 22 42Z" stroke="#A4D934" strokeWidth="3"/>
                            </svg>
                        </button>
                    </div>
                </div>
            </div>
        </>
    );

}

export const TaskItemCompleted = ({tittle}) => {
    return (
        <>
            <img className='w-4 h-4 opacity-0 mr-1' src="src/assets/DragIcon.svg" alt="Drag" style={{ pointerEvents: 'none', userSelect: 'none' }} />
            <div className='w-11/12 contenedor-opacidad rounded-md'>
                <div className='flex w-full h-full flex-row p-1'>
                    <div className="flex flex-1 items-center text-ellipsis whitespace-nowrap">
                        <strong className='text-white text-lg font-bold ml-2 '>{tittle}</strong>
                    </div>
                    <div className="flex justify-end gap-2 items-center pl-2 pr-2">
                        <span>completed</span>
                        <button disabled className="h-full w-4 flex items-center justify-center p-0 mr-0 outline-none border-none bg-transparent focus:outline-none" style={{ overflow: 'visible' }}>
                            <svg width="20" height="20" viewBox="0 0 52 52" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path opacity="0.1" d="M1 26C1 5.4125 5.4125 1 26 1C46.5875 1 51 5.4125 51 26C51 46.5875 46.5875 51 26 51C5.4125 51 1 46.5875 1 26Z" fill="#519A45"/>
                                <path d="M1 26C1 5.4125 5.4125 1 26 1C46.5875 1 51 5.4125 51 26C51 46.5875 46.5875 51 26 51C5.4125 51 1 46.5875 1 26Z" stroke="#519A45" strokeWidth="2"/>
                                <path d="M17.6665 25.9999L22.3409 30.6743C22.8276 31.161 23.6165 31.161 24.1032 30.6743L34.3332 20.4443" stroke="#519A45" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"/>
                            </svg>
                        </button>
                    </div>
                </div>
            </div>
        </>
    );

}

