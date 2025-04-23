// src/controllers/authController.ts
import { Request, Response } from 'express';
import { users } from '../Models/userModel';

export class AuthController {
    public login(req: Request, res: Response) {
        const { username, password } = req.body;

        // Buscar el usuario en la "base de datos"
        const user = users.find(u => u.username === username && u.password === password);

        if (user) {
            // Autenticación exitosa
            res.send(`Bienvenido, ${user.username}!`);
        } else {
            // Autenticación fallida
            res.status(401).send('Credenciales incorrectas');
        }
    }
}