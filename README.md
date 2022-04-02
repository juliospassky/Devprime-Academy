# Devprime-Academy
Treinamento na plataforma de desenvolvimento devprime https://devprime.tech/

# --------------------------------- Parte 1 ------------------------------------------

## Iniciando um novo projeto

Instalação do CLI:
```sh
dotnet tool install -g devprime.cli
```

Logar no CLI com a licença adquirida:
```sh
dp auth
```

Criando uma rede docker:
```sh
docker network create devprime
```

## DDD do projeto

<p align="center">
<img src="https://github.com/juliospassky/Devprime-Academy/blob/main/imgs/001-DDD.png">
</p>

## Criando um novo projeto

Iniciando um novo projeto com mongodb e rabbitmq
```sh
dp new order-ms --state mongodb --stream rabbitmq
```

Executando o projeto
```sh
.\run.sh
```

## Domínio da aplicação

Criando as classes de domínio da aplicação (Pré-configuradas a título de exemplo do devprime)
```sh
dp marketplace Order
```

## Acelerando o desenvolvimento
O seguinte comando, implementa várias funcionalidades pré-estabelecidas dentro do microsserviço
```sh
dp init
```

Com o comando, é criado os padrões: persistência (Repository); Adapter Web com endpoints no formato Minimal APIs; DTOS; Event Handlers; Implementações de Testes de unidade; Injeção de dependência.


# --------------------------------- Parte 2 ------------------------------------------


