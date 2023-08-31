# Sistema de Gerenciamento de Agência de Viagens

> **O projeto consiste no desenvolvimento de um sistema full-stack para uma agência de viagens, que visa automatizar e otimizar as operações administrativas de cadastro e manutenção de pacotes de viagem. A aplicação será construída utilizando a tecnologia ASP.NET Core MVC e se integrará a um banco de dados MySQL para armazenar as informações relevantes. A implementação incluirá funcionalidades como login, manipulação de pacotes de viagem e controle de acesso.**

**Funcionalidades Planejadas:**
- Login e Controle de Acesso:
- Foi implementada uma página de login onde os usuários poderão autenticar-se.
- A autenticação será realizada através de um banco de dados.
- Apenas os usuários autenticados terão acesso ao sistema.
- Foi utilizado o conceito de sessão para manter o usuário autenticado durante a navegação.

**Manipulação de Pacotes de Viagem:**
- Páginas serão criadas para inclusão, exclusão e listagem de pacotes de viagem.
- Os pacotes de viagem incluirão informações como destino, data, preço e detalhes.
- Os dados dos pacotes serão armazenados no banco de dados MySQL.

**Controle de Acesso ao Cadastro de Pacotes:**
- Apenas os usuários autenticados terão permissão para cadastrar novos pacotes de viagem.
- Implementada uma restrição de acesso para garantir que somente usuários logados possam acessar a funcionalidade de cadastro.

Utilizei o ASP.NET Core MVC para criar uma interface web amigável e interativa, permitindo que os usuários realizem operações de maneira eficiente. O banco de dados MySQL será empregado para armazenar e gerenciar as informações relacionadas aos pacotes de viagem.

> **Observação: Para interligar as duas tabelas do banco de dados, recorri ao uso de chaves estrangeiras (foreign keys) para estabelecer relações entre os dados de forma consistente e eficiente. Isso nos permite manter a integridade e a coesão das informações armazenadas nas diferentes tabelas.**

##

![Languages](https://github-readme-stats.vercel.app/api/top-langs/?username=wincklerhigher&repo=Travel_Manager)
