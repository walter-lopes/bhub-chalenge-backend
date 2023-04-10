# Como você consegue domar um conjunto de regras de negócio que mudam o
tempo todo?

Como parte do desafio da BHub, escolhi algumas alternativas que podem ajudar a resolver o problem de termos uma aplicação que contém regras de negócios
complexas e que mudam o tempo todo. 
Abaixo mostrarei alguns padrões escritos em c#, que tornam esse problema mais fácil de resolver. Isso pode ser aplicado em qualquer linguagem, foque no conceito.


## O que fazer quando temos muitas regras de negócio?


Quando enfrentamos uma aplicação onde temos um número muito grande de regras de negócio, nosso primeiro pensamento deve ser, como desacoplar e separar a responsabilidade
para contextos que fazem sentido.
Basicamente a maneira mais fácil de resolver esse problema é implementando várias tomadas de decisões de acordo com que a demanda venha. Porém usando esse mecanismo
nosso código ficará totalmente acoplado, dificil de ter uma boa leitura, manutenção e testabildade. Jamais faça algo do tipo

```
switch (payment.PaymentType)
    {
        case PaymentType.Book:
            // Do something
            break;
        case PaymentType.Membership:
            // Do something
            break;
        case PaymentType.Upgrade:
            // Do something
            break;
    }
```

Como falado a anteriomente, para esse tipo de problmea precisamosa de desacoplamento e resposabilidade única. Nosso foco é deixar o código mais entendivel possivel
e mais fácil de testar/manter. Usando práticas como Dependency Injectio e Abstrações conseguimos alcançar um bom nível de código para nossa aplicação.

