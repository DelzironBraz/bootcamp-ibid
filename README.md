# bootcamp-ibid

Esse projeto foi criado utilizando a plataforma Microsoft Visual Studio. As tecnologias usadas para o desenvolvimento desse projeto foi:
* C#
* Bootstrap
* ASP.NET Web Forms
* SQL Server

## Teste específico: mão na massa - Bootcamp 4ª edição

Esse projeto foi craido com o intuito de desenvolver uma aplicação ASP.NET Web para um desafio técnico, no qual foi solicitado a criação de um CRUD simples.

## Instruções para o Build

O projeto deve ser executado na plataforma Microsoft Visual Studio.

O código fornecido abaixo é para a criação da tabela:
```
CREATE TABLE clients (
  id INT NOT NULL PRIMARY KEY IDENTITY,
  name VARCHAR (100) NOT NULL,
  email VARCHAR (150) NOT NULL UNIQUE,
  phone VARCHAR(20) NULL,
  address VARCHAR(100) NULL,
  created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
  
INSERT INTO clients (name, email, phone, address)
VALUES
  ('João da Silva', 'joao.silva@example.com', '123-456-7890', 'Rua A, nº 123'),
  ('Maria Santos', 'maria.santos@example.com', '987-654-3210', 'Avenida B, nº 456'),
  ('Carlos Pereira', 'carlos.pereira@example.com', '555-123-7890', 'Rua C, nº 789'),
  ('Ana Rodrigues', 'ana.rodrigues@example.com', '444-789-1230', 'Avenida D, nº 101'),
  ('Fernanda Oliveira', 'fernanda.oliveira@example.com', NULL, 'Rua E, nº 202');

```
Ápos a criação da tabela, a aplicação está pronta para ser executada com o comando ctrl + f5.
