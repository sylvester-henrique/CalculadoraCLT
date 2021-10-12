# CalculadoraCLT
Biblioteca que permite realizar cálculos de acordo com algums leis da CLT (Consolidação de Leis de Trabalho) brasileira.

A biblioteca atualmente possui as funcionalidades:
- Cálculos feitos a partir do salário bruto:
  - desconto do INSS
  - desconto do IRRF
  - salário líquido
  - porcentagem do total de descontos
  - valor total de descontos
- Cálculos de FGTS
  - cálculo de FGTS a partir do salário bruto 
  - cálculo do valor do saque aniversário a partir do saldo do FGTS
  - cálculo de previsões dos próximos saques aniversário do FGTS
  
# Exemplos 
Todas as classes da blibliotaca possuem um construtor padrão, que não tem nenhum parâmetro. Caso a classe seja instanciada com o construtor padrão, os cálculos realizados vão considerar as regras da CLT vigentes no ano de 2021.
As classes também suportam configurações personalizadas (passadas pelo construtor) que serão detalhadas a seguir.

## FGTS
Para fazer cálculo de saque aniversário e cálculo de valor do FGTS do mês de acordo com a regra de 2021, basta utilizar o construtor padrão:
```cs
var fgts = new FGTS();
var fgtsMes = fgts.Calcular(salario: 10000);
var saque = fgts.SaqueAniversario(saldoFgts: 30000);
```
Também é possível fazer o cálculo de futuros saques do FGTS segundo a regra do Saque Aniversário. Esse exemplo, calcula a previsão dos valores de saque do FGTS nos próximos 10 anos, considerando um salário médio no período:

```cs
var previsaoSaque = fgts.PrevisaoSaques(
    saldoFgts: 30000,
    salarioMedio: 10000,
    mesInicio: DateTime.Now.Month,
    mesAniversario: 4,
    quantidadeAnos: 10
);
Console.WriteLine("Previsão dos saques do FGTS:");
foreach (var s in previsaoSaque.Saques)
{
    Console.WriteLine($"Valor do saque: {s}");
}
Console.WriteLine($"Saldo final: {previsaoSaque.SaldoFinal}");
```
É possiver difinir limites para saque do FGTS diferentes dos limites definidos em 2021:
```cs
var faixasSaqueFgts = new FaixaSaqueFGTS[]
{
    new FaixaSaqueFGTS { LimiteSuperior = 600, Aliquota = 0.75, ParcelaAdicional = 0 },
    new FaixaSaqueFGTS { LimiteSuperior = 1050, Aliquota = 0.55, ParcelaAdicional = 500 },
    new FaixaSaqueFGTS { LimiteSuperior = 4500, Aliquota = 0.3, ParcelaAdicional = 750 },
};
var fgts = new FGTS(faixasSaqueFgts);
```
**OBS:** As classes de cálculo de INSS e IRRF também possuem construtores que aceitam configurações diferentes para a realização de seus respectivos cálculos.
## Salario
É possível calcular o salário líquido a partir do salário bruto.
```cs
var salario = new Salario();
var salarioLiquido = salario.SalarioLiquido(13000);
```
 Também é possível instanciar ```Salario``` passando como parâmetro, diferentes implementações de ```IINSS``` e ```IIRRF```:
```cs
IINSS inss = new MinhaImplementacaoDeINSS();
IIRRF irrf = new MinhaImplementacaoDeIRRF();
var salario = new Salario(inss, irrf);
```

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
