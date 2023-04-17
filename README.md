# Como você consegue domar um conjunto de regras de negócio que mudam o tempo todo?

Como parte do desafio da BHub, escolhi algumas alternativas que podem ajudar a resolver o problem de termos uma aplicação que contém regras de negócios
complexas e que mudam o tempo todo. 
Abaixo mostrarei alguns padrões escritos em c#, que tornam esse problema mais fácil de resolver. Isso pode ser aplicado em qualquer linguagem, foque no conceito.


## Arquitetura de plugins pode nos ajudar a tornar regras de negócios flexiveis.


Primeiramente com o primeiro feedback feito pelo Gustavo, onde minha solução não resolvia o problema de solicitar sempre um novo deploy a cada atualização feita no sistema. Ao realizar alguns estudos verifiquei que de fato não era a melhor solução e encontrei a arquitetura baseada em plugins para nos ajudar.

A arquitetura baseada em plugins é um estilo de arquitetura de software em que um sistema é projetado para ser estendido ou personalizado por meio de plugins, que são módulos de código que podem ser adicionados ou removidos dinamicamente para adicionar ou modificar funcionalidades do sistema. Existem várias vantagens em usar uma arquitetura baseada em plugins, aqui algumas vantagens:

- A arquitetura baseada em plugins permite que o software seja dividido em módulos independentes e isolados, o que facilita a manutenção e a evolução do sistema. Cada plugin pode ser desenvolvido e testado de forma separada, sem afetar o funcionamento dos outros plugins ou do sistema como um todo. Isso torna o software mais modular e flexível, permitindo que as mudanças sejam feitas em partes específicas do sistema sem afetar o funcionamento geral.

- Uma das principais vantagens da arquitetura baseada em plugins é a capacidade de adicionar novas funcionalidades ao sistema sem a necessidade de modificar o código existente. Os plugins podem ser desenvolvidos e adicionados ou removidos do sistema de forma independente, sem a necessidade de recompilar ou reiniciar o software. Isso permite que novas funcionalidades sejam facilmente incorporadas ao sistema sem interromper a operação do software em produção.

 - Com a arquitetura baseada em plugins, a atualização de funcionalidades do sistema pode ser mais fácil e menos arriscada. Os plugins podem ser atualizados de forma independente, sem a necessidade de atualizar todo o sistema. Isso permite que as atualizações sejam aplicadas com mais rapidez e facilidade, minimizando o risco de interrupção do sistema.
 
 ## Como utilizar?
 
 
 Primeiro para exemplicar criei duas class libraries chamadas de BookPaymentPlugin e PhysicalProductPaymentPlugin respectivamente, onde iremos implementar/alterar nossas regras de negócio conforme demanda. Para isso basta criar uma classe concreta que implementa a interface IPlugin.
 
 ```
public class BookPaymentPlugin : IPlugin
{
        /// <summary> Plugin Name </summary>
        public string Name { get; } = "BookPayment";
        
        /// <summary> Execute </summary>
        public void DoAction()
        {
            Console.WriteLine("Retrieving current book payment and running the business rule.");
        }
}
```

Toda classe que implementa o IPlugin deve ter o método DoAction, que será sempre chamado uma vez que o plugin for criado.
 
Nesse exemplo em C#, os plugins são baseados em DLLs. Para adicionar ou alterar um plugin, basta acessarmos o caminho dos plugins na aplicação e copiar e colar a nova dll gerada.
 Copiar DLL do plugin gerada e colar no caminho dos plugins da aplicação.
 ```
/caminho-da-app/Plugins
```

Isso fará com que o novo plugin adicionado ou atualizado, comece a rodar sem precisarmos de um novo na aplicação, trazendo flexibidade e facilidade para o time de desenvolvimento.


### Referências

https://github.com/weikio/PluginFramework
https://youtu.be/iCE1bDoit9Q

