# Como você consegue domar um conjunto de regras de negócio que mudam o tempo todo?

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


# Dependency Injection

Podemos deixar a responsabilidade por determinar qual classe de negócio ser instanciada pelo nosso DI, usando uma estrategia chamada Conditional Dependency Injection.

```

        services.AddTransient<Func<PaymentType, IPaymentBusinessRule>>(serviceProvider => key =>
        {
            return key switch
            {
                PaymentType.Book => serviceProvider.GetService<BookPaymentBusinessRule>(),
                PaymentType.Membership => serviceProvider.GetService<MembershipPaymentBusinessRule>(),
                PaymentType.Upgrade => serviceProvider.GetService<UpgradePaymentBusinessRule>(),
                PaymentType.PhysicalProduct => serviceProvider.GetService<PhysicalProductBusinessRule>(),
                _ => throw new Exception("Concrete class doesn't exist.")
            };
        });
```

Dessa maneira conseguimos evitar os multiplos if's em nosso fluxo de negócio, deixando essa responsabilidade para uma camada de IoC.

Por fim o código no fluxo de negócio ficaria nesse estilo

```
var serviceCollection = new ServiceCollection();
serviceCollection.AddPaymentBusinessRules();
var provider = serviceCollection.BuildServiceProvider();

var payment = new Payment
{
    PaymentType = PaymentType.Book
};
await PostPayment(payment);

async Task PostPayment(Payment payment)
{
    var service = provider.GetService<Func<PaymentType, IPaymentBusinessRule>>();

    var businessRule = service?.Invoke(payment.PaymentType);
    await businessRule?.ExecuteAsync(payment)!;
}

```

# Facilitade nos testes

Usando essa maneira, conseguiremos testar nossa aplicação de uma forma muito mais eficaz! Já que criamos uma classe de business rules para cada comando, isso nos permite realizar testes distintos de cada regra de negócio. 

## Teste se o pagamento for um upgrade para uma associação,
```

    [Test]
    public void Should_Send_Activation_Email()
    {
        //Arrange
        var businessRule = new MembershipPaymentBusinessRule();
        var payment = new Payment() {PaymentType = PaymentType.Membership};
        
        //Act
        businessRule.ExecuteAsync(payment);
        
        //Asserts
    }

```

## Teste se o pagamento for para um livro, crie uma guia de remessa duplicada para o
departamento de royalties.

```

    [Test]
    public void Should_Generate_Duplicated_Delivery_Note_To_Royalties_Staff()
    {
        //Arrange
        var businessRule = new PhysicalProductBusinessRule();
        var payment = new Payment() {PaymentType = PaymentType.Book};
        
        //Act
        businessRule.ExecuteAsync(payment);
        
        //Asserts
    }

```
 # Conclusão
 
 
 Essa estratégia faz com que nosso código seja totalmente escalavel e de fácil manutenção, já que sabemos onde está cada componente de negócio.
