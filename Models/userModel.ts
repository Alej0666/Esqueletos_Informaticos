// src/models/userModel.ts
export interface User {
    username: string;
    password: string; // En un entorno real, las contraseñas deben ser hasheadas
    role: string; // Rol del usuario (admin, user, etc.)
}

export const users: User[] = [
    { username: 'admin', password: 'password123', role: 'Admin' }, 
    { username: 'user', password: 'password123', role: 'User' },
]

const loginForm = document.getElementById('loginForm') as HTMLFormElement;
const messageDiv = document.getElementById('message') as HTMLDivElement;
const recoverPasswordButton = document.getElementById('recoverPassword') as HTMLButtonElement;

// Verificar si el usuario ya ha iniciado sesión
if (localStorage.getItem('loggedInUser ')) {
    const loggedInUser  = JSON.parse(localStorage.getItem('loggedInUser ')!);
    messageDiv.textContent = `Ya has iniciado sesión como ${loggedInUser .username}.`;
    messageDiv.style.color = 'green';
    // Aquí podrías redirigir a otra página si lo deseas
}

// Agregar un evento al formulario para manejar el envío
loginForm.addEventListener('submit', (event) => {
    event.preventDefault(); // Prevenir el comportamiento por defecto del formulario

    // Obtener los valores de los campos de entrada
    const username = (document.getElementById('username') as HTMLInputElement).value;
    const password = (document.getElementById('password') as HTMLInputElement).value;

    // Autenticar al usuario
    const user = authenticate(username, password);
    if (user) {
        messageDiv.textContent = `Inicio de sesión exitoso! Rol: ${user.role}`;
        messageDiv.style.color = 'green';

        // Guardar el usuario en localStorage
        localStorage.setItem('loggedInUser ', JSON.stringify(user));

        // Redirigir a la página principal después de un inicio de sesión exitoso
        setTimeout(() => {
            window.location.href = 'index.html'; // Cambia 'index.html' por la URL de tu página principal
        }, 2000); // Esperar 2 segundos antes de redirigir
    } else {
        messageDiv.textContent = 'Usuario o contraseña incorrectos.';
        messageDiv.style.color = 'red';
    }
});

// Función para autenticar al usuario
function authenticate(username: string, password: string): User | null {
    return users.find(user => user.username === username && user.password === password) || null;
}

// Función para recuperar la contraseña
function recoverPassword(username: string): string {
    const user = users.find(user => user.username === username);
    if (user) {
        return `La contraseña para ${username} es: ${user.password}`;
    } else {
        return 'Usuario no encontrado.';
    }
}

// Evento para el botón de recuperación de contraseña
recoverPasswordButton.addEventListener('click', () => {
    const username = (document.getElementById('username') as HTMLInputElement).value;
    const recoveryMessage = recoverPassword(username);
    messageDiv.textContent = recoveryMessage;
    messageDiv.style.color = 'blue';
});
