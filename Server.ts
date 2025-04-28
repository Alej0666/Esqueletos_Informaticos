// src/server.ts
import express from 'express';
import bodyParser from 'body-parser';
import path from 'path';
import { AuthController } from './Controllers/authController';

const app = express();
const port = 3000;

// Middleware
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

// Servir archivos estáticos (Muy importante)
app.use(express.static(path.join(__dirname, 'views')));

// Configurar EJS como motor de plantillas (opcional, si usas HTML plano no lo necesitas realmente)
app.set('view engine', 'ejs');
app.set('views', path.join(__dirname, 'views'));

// Rutas
app.get('/Login.html', (req, res) => {
    res.sendFile(path.join(__dirname, 'views', 'Login.html'));
});

const authController = new AuthController();
app.post('/Login.html', (req, res) => authController.login(req, res));

// Iniciar el servidor
app.listen(port, () => {
    console.log(`Servidor escuchando en http://localhost:${port}`);
});
