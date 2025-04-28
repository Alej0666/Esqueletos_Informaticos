// src/controllers/authController.ts
import { Request, Response } from 'express';
import { users } from '../Models/userModel';

export class AuthController {
    public login(req: Request, res: Response) {
        const { username, password } = req.body;

        // Buscar el usuario en la "base de datos"
        const user = users.find(u => u.username === username && u.password === password);

        if (user) {
            res.json({ username: user.username, role: user.role });
        } else {
            res.status(401).json({ message: 'Credenciales incorrectas' });
        }        
    }
} 

