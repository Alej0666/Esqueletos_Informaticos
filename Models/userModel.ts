// src/models/userModel.ts
export interface User {
    username: string;
    password: string; // En un entorno real, las contraseñas deben ser hasheadas
}

export const users: User[] = [
    { username: 'admin', password: 'password123' }, // Ejemplo de usuario
];