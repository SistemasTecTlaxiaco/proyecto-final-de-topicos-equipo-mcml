-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         11.7.2-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.10.0.7000
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Volcando datos para la tabla agendatarea.login: ~5 rows (aproximadamente)
INSERT INTO `login` (`id`, `Usuario`, `Contraseña`, `Correo`) VALUES
	(1, 'mari', '1234', 'mari@correo.com'),
	(2, 'juanperez', 'juan123', 'juanperez@gmail.com'),
	(3, 'mariagomez', 'maria456', 'mariagomez@hotmail.com'),
	(4, 'carloslopez', 'carlos789', 'carlos.lopez@yahoo.com'),
	(5, 'anaruiz', 'ana321', 'ana.ruiz@outlook.com');

-- Volcando datos para la tabla agendatarea.tarea: ~5 rows (aproximadamente)
INSERT INTO `tarea` (`id`, `titulo`, `descripcion`, `fecha_vencimiento`, `categoria`, `prioridad`) VALUES
	(3, 'Llamar al hermana', 'Platicar', '2025-05-21', 'Personal', 'Media'),
	(4, 'Estudiar SQL', 'Repasar comandos de SQL para el examen.', '2025-05-25', 'Estudios', 'Alta'),
	(5, 'Pagar servicios', 'Pagar agua, luz y teléfono.', '2025-05-19', 'Personal', 'Urgente'),
	(6, 'Compra', 'frutas', '2025-05-18', 'Personal', 'Media'),
	(7, 'CRUD', 'Agreggar, Modificar, Eliminar y limpiar', '2025-05-18', 'Escuela', 'Alta');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
