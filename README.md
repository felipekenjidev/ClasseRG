# Classe C# para Validação de RG
Uma Classe C# com métodos e propriedades para realizar a verificação do RG (Registro Geral), formatando seus dígitos e indicando se o documento digitado é Verdadeiro ou Falso.

# Preparação
Antes de poder utilizar a Classe RG, é necessário importar para dentro do projeto, colocando o próprio arquivo `clsRG.cs` dentro do projeto ou adicionando uma referência para a DLL `clsRG.dll`.

# Como Funciona?
Para utilizar basta instanciar a Classe RG, passando no parâmetro o RG a ser verificado. Pode passar o RG tanto com as pontuações como `18.845.634-X` ou sem como `18845634X`.

`RG variavel = new RG("18845634X");`

Após instanciar a Classe, apenas é preciso acessar o método `Validar()` que o resultado da verificação será gerado.

`bool resposta = variavel.Validar()`
