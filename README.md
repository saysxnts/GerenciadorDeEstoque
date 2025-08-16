# Sistema de Gerenciamento de Estoque em C#

![Status](https://img.shields.io/badge/status-conclu%C3%ADdo-brightgreen)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

## 📖 Sobre o Projeto

Esta é uma aplicação de console desenvolvida em C# para simular um sistema básico de gerenciamento de estoque. O programa permite ao usuário adicionar, listar, atualizar e remover produtos. A principal característica do projeto é a persistência de dados: o estado do estoque é salvo em um arquivo `estoque.json` ao fechar o programa e recarregado ao iniciar.

O projeto serve como um exercício prático para aprofundar os conceitos de Programação Orientada a Objetos (OOP), manipulação de coleções e persistência de dados em arquivos.

---

## ✨ Funcionalidades

- Adicionar um novo produto ao estoque (nome, quantidade, preço).
- Listar todos os produtos cadastrados com seus detalhes.
- Atualizar a quantidade de um produto existente através de seu ID.
- Remover um produto do estoque pelo ID.
- Persistência de dados em um arquivo `estoque.json` na raiz do projeto.

---

## 🛠️ Tecnologias e Conceitos Praticados

- **C#** e o ecossistema **.NET**.
- **Programação Orientada a Objetos:** Uso da classe `Produto` para modelar os dados.
- **Coleções:** Gerenciamento dos produtos em memória usando `List<Produto>`.
- **Manipulação de Arquivos (`System.IO`):** Leitura e escrita de arquivos de texto.
- **Serialização/Desserialização de JSON:** Uso da biblioteca `System.Text.Json` para converter a lista de objetos em texto JSON e vice-versa.
- **LINQ (Language-Integrated Query):** Uso de métodos como `FirstOrDefault()`, `Max()` e `Any()` para consultar a lista de produtos.

---

## 🚀 Como Rodar o Projeto

### **Pré-requisitos**

- **.NET SDK** (versão 6.0 ou superior).

### **Instalação e Execução**

1.  **Clone o repositório**:
    ```bash
    git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/seu-usuario/seu-repositorio.git)
    ```

2.  **Navegue até a pasta do projeto**:
    ```bash
    cd GerenciadorDeEstoque
    ```

3.  **Execute a aplicação**:
    ```bash
    dotnet run
    ```
4.  O menu interativo aparecerá no seu terminal. Siga as instruções para gerenciar o estoque. Ao sair (opção 5), um arquivo `estoque.json` será criado ou atualizado na pasta do projeto.

---

## ✒️ Autor

**Guilherme**
