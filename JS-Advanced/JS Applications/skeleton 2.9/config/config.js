export const url = 'https://testskeleton-c4c14.firebaseio.com/'
export const collectionName = 'causes'

export default (() => {
    // Your web app's Firebase configuration
    var firebaseConfig = {
        apiKey: "AIzaSyDcjGW49wdMgdjTlR4nIu3XQJ2Ce-X3dDE",
        authDomain: "testskeleton-c4c14.firebaseapp.com",
        databaseURL: "https://testskeleton-c4c14.firebaseio.com",
        projectId: "testskeleton-c4c14",
        storageBucket: "testskeleton-c4c14.appspot.com",
        messagingSenderId: "168727016838",
        appId: "1:168727016838:web:c51107bbec23bddb22a807"
    };
    // Initialize Firebase
    firebase.initializeApp(firebaseConfig);
})()