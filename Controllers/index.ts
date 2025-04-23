// Definición de la interfaz para el usuario
interface User {
    username: string;
    password: string;
}

// Lista de usuarios simulados (en un entorno real, esto vendría de una base de datos)
const users: User[] = [
    { username: 'user1', password: 'password1' },
    { username: 'user2', password: 'password2' },
];

// Obtener elementos del DOM
const loginForm = document.getElementById('loginForm') as HTMLFormElement;
const messageDiv = document.getElementById('message') as HTMLDivElement;

// Agregar un evento al formulario para manejar el envío
loginForm.addEventListener('click', (event) => {
    event.preventDefault(); // Prevenir el comportamiento por defecto del formulario

    // Obtener los valores de los campos de entrada
    const username = (document.getElementById('username') as HTMLInputElement).value;
    const password = (document.getElementById('password') as HTMLInputElement).value;

    // Autenticar al usuario
    if (authenticate(username, password)) {
        messageDiv.textContent = 'Inicio de sesión exitoso!';
        messageDiv.style.color = 'green';
    } else {
        messageDiv.textContent = 'Usuario o contraseña incorrectos.';
        messageDiv.style.color = 'red';
    }
});

// Función para autenticar al usuario
function authenticate(username: string, password: string): boolean {
    return users.some(user => user.username === username && user.password === password);
}