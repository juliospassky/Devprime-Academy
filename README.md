# Devprime-Academy
Treinamento na plataforma de desenvolvimento devprime https://devprime.tech/

# ---------- Parte 1 ----------

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

| Docker Tool   | Command       |
| ------------- |:-------------:|
| MongoDB       | docker run --network devprime --name mongodb -p 27018:27018 -p 27019:27019 -p 27017:27017 -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=LltF8Nx*yo -d mongo |
| RabbitMQ      | docker run --network devprime --name rabbitmq -d -p 5672:5672 -p 15672:15672 -t rabbitmq:3-management |

# ---------- Parte 2 ----------

## DDD do projeto

<p align="center">
<img src="https://github.com/juliospassky/Devprime-Academy/blob/main/imgs/001-DDD.png">
</p>

## Criando um novo projeto (order-ms)

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

# ---------- Parte 3 ----------

Iniciando um segundo projeto (payment-ms) com mongodb e rabbitmq
```sh
dp new payment-ms --state mongodb --stream rabbitmq
```

## Domínio da aplicação

Criando as classes de domínio da aplicação pelo comando de aggregate
No terminal do Visual Studio (Tools -> Nuget Package Manager -> Package Manager) digitar o seguinte comando
```sh
dp add aggregate Payment
```

Adicionar as propriedades no aggregate do Payment (Core -> Domain -> Aggregates -> Payment) 
```cs
	public string CustomerName { get; private set; }
    public Guid OrderId { get; private set; }
    public double Value { get; private set; }
```

## Acelerando o desenvolvimento
O seguinte comando, implementa várias funcionalidades pré-estabelecidas dentro do microsserviço
```sh
dp init
```

Associcando o evento ao serviço
```sh
dp add event OrderCreated -as PaymentService
```

Adicionar as propriedades no DTO do Payment OrderCreatedEventDTO (Core -> Application -> Services -> Payment -> Model)
```cs
	public string CustomerName { get; set; }
    public string CustomerTaxId { get; set; }
    public double Total { get; set; }
    public Guid ID { get; set; }
```

Realizar o mapeamento do DTO na classe de EventStream (Adapters -> DevPrime -> Stream)
```cs
	var command = new Payment()
	{
		CustomerName = dto.CustomerName,
		OrderId = dto.ID,
		Value = dto.Total
	};

	paymentService.Add(command);
```
A aplicação não deve realizar um novo evento de criação, para isso, deve-se excluir a linha de Send da classe PaymentCreatedEventHandler (Core -> Application -> EventHandlers -> Payment)
```cs
	//Dp.Stream.Send(destination, eventName, eventData);
```

Adicionar o evento no arquivo de configuração (App -> appsettings.json), localizar "DevPrime_Stream" e alterar o Subscribe para: 
```cs
 "Subscribe": [
        {
          "queues": "orderevents"
        }
      ]
```

Ainda no arquivo de configuração, alterar as portas da aplicação
```cs
	"url": "https://localhost:5003;http://localhost:5002",
```

Todas as configurações foram concluídas para o propósito das aplicações, dessa forma, pode-se executar e testar as aplicações.


# ---------- Parte 4 ----------

## Fluxo da aplicação

<p align="center">
<img src="https://github.com/juliospassky/Devprime-Academy/blob/main/imgs/002-Flow.png">
</p>

<p align="center">
<img src="https://github.com/juliospassky/Devprime-Academy/blob/main/imgs/003-Pipeline.png">
</p>

