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
loginForm.addEventListener('submit', async (event) => {
    event.preventDefault();

    const username = (document.getElementById('username') as HTMLInputElement).value;
    const password = (document.getElementById('password') as HTMLInputElement).value;

    try {
        const response = await fetch('/Login.html', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, password }),
        });

        if (response.ok) {
            const user = await response.json(); // asumiremos que el backend devuelve info del usuario
            localStorage.setItem('loggedInUser', JSON.stringify(user));
            window.location.href = '/Index.html'; // redireccionar
        } else {
            messageDiv.textContent = 'Usuario o contraseña incorrectos.';
            messageDiv.style.color = 'red';
        }
    } catch (error) {
        console.error('Error durante el login:', error);
    }
});

// Función para autenticar al usuario
function authenticate(username: string, password: string): boolean {
    return users.some(user => user.username === username && user.password === password);
}