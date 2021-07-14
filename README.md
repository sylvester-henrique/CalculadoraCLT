# CalculadoraCLT
Biblioteca que permite realizar cálculos de acordo com algums leis da CLT (Consolidação de Leis de Trabalho) brasileira.

A biblioteca atualmente possui as funcionalidades:
- Cálculos feitos a partir do salário bruto:
  - desconto do INSS
  - desconto do IRRF
  - salário líquido
  - porcentagem do total de descontos
  - valor total de descontos
  
  
 # Inspiração
 Inicialmente essa biblioteca foi criada com objetivo de praticar e aplicar conhecimentos de TDD, testes unitários e princípios SOLID.
 
 **TDD**: esse projeto foi desenvolvido usando a cliclo do TDD (Test Driven Design), basicamente segui o passo a passo:
  - escrever teste
  - ver teste falhar
  - implementar código mais simples para fazer o teste passar
  - ver o teste passar
  - refatorar o código se necessário
  - repetir esse fluxo
  
  **Testes Unitários**: Testes realizados em unidades de código testáveis (classes). Realizei testes unitários usando a ferramenta [XUnit](https://xunit.net/)
  
  **SOLID**: os princípios SOLID foram seguidos nesse projeto:
  - **`S`ingle responsibility principle**: diz respeito à alta coesão, classes devem ser coesas em quais tarefas realizam, ou seja, não podem ter muitas responsabilidades. Uma classe deve ter apenas um motivo para ser modificada. Nesse projeto as classes têm alta coesão,  por exemplo, a classe IRRF.cs apenas realiza lógica de cálculo de imposto de renda, enquanto a classe INSS.cs apenas realiza lógica de cálculo do INSS. Caso tenha uma alteração na lógica de negócio no cálculo de INSS, isso acarretaria em mudanças apenas na classe INSS.cs.
  - **`O`pen-closed principle**: o princípio do aberto-fechado diz que uma classe deve estar aberta a extensões e fechada a modificações. Nesse projeto, temos a interface IINSS que contém o método `calcula(double salarioBruto)`. Além disso temos a classe INSS.cs que implementa essa interface. Depois, para deixar a biblioteca mais completa, decidi que queria uma funcionalidade de fazer cálculo do INSS na fórmua antiga (usada até Fevereiro de 2020). Esse *design* de classes em que existe a interface IINSS e a classe INSS.cs, permitiu extender a funcionalidade de cálculo de INSS sem que a implementação de INSS.cs fosse modificada, por meio de uma classe INSSAntigo.cs que implementa IINSS.
  - **`L`iskov substitution principle**: princípio que diz que uma classe base pode ser substituída por qualquer uma de suas classes filhas sem que haja efeitos colaterais na aplicação. Nesse projeto ainda não tiveram heranças de classes, logo o princípio não foi violado. A ideia é que caso seja necessária alguma herança, a classe filha não altere o comportamento da classe pai.
  - **`I`nterface segregation principle**:  princípio que diz que interfaces devem ser segregadas, quando têm muitas responsabilidades. Classes não devem ser obrigadas a implementar métodos que não usam. Nesse projeto esse princípio não é violado, as interfaces não são "gordas", ou seja não tem muitas responsabilidades e suas implementações não são obrigadas a usar métodos que não usam.
  - **`D`ependency inversion principle**:  diz que quando classes dependem umas das outras é melhor que elas dependam de abstrações do que de implementações específicas, porque abstrações são menos propensas a ter alterações do que implementações específicas. Nesse projeto as dependências são especificadas por meio de interfaces, por exemplo, a classe IRRF.cs depende da interface IINSS. Caso uma implementação de IINSS sofra alguma alteração isso não vai afetar a implementação de IRRF.cs, porque essa classe depende apenas da interface IINSS, logo não precisa se preocupar com a lógica de sua implementação.
