# Avaliação Técnica - Desenvolvimento de uma Web API de Programa de Fidelidade
## Descrição do problema
#### Regras:
1. Enviar o teste em arquivo compactado ou utilizar seu repositório pessoal de GitHub.
2. As tecnologias e arquiteturas utilizadas devem respeitar as mencionadas a seguir (na seção tecnologias/arquiteturas).
3. Na seção requisitos é explanado o contexto e descrita as funcionalidades esperadas, não será avaliado a ‘quantidade’ de funcionalidades entregues, e sim a qualidade das funcionalidades entregues, dentro do tempo disponível.
4. Arquivo do Postman com requisições exemplo para consumo.
5. A solução deve conter um projeto de testes unitários.

#### Tecnologias/Arquiteturas:
1. .NET Core 3.1 (ou superior)
2. MySQL 8.0 (ou superior)
3. Docker 2.0 (ou superior)
4. Testes Unitários (XUnit)

#### Requisitos:
A Empresa Z possui um produto que é o “Programa de Fidelidade Empresa Z" que são empresas que se unem com o objetivo de recompensar os seus clientes (que consomem seus produtos) através de uma moeda que pode ser trocada por produtos ou serviços. Este programa é de coalizão, ou seja, não existe apenas uma empresa distribuindo a moeda de recompensa e sim várias empresas que distribuem esta mesma, sendo assim o usuário pode ganhar tanto no posto de gasolina quanto na farmácia e acumular isto em uma mesma conta. Mas, para acumular estes pontos, o usuário precisa estar cadastrado neste programa e sua identificação no programa é o e-mail. Com estes pontos acumulados o usuário pode trocar por produtos no site do programa, que estão divididos em várias categorias (CDs, DVDs, Livros, Viagem, etc) e dentro das categorias em subcategorias, esta troca é tratada e entregue pela própria Empresa Z. Com base nesses requisitos, desenvolva uma Web API que permita qualquer desenvolvedor interagir com o Programa de Fidelidade Empresa Z, disponibilizando as funções abaixo:
1. Cadastro de Usuário;
2. Autenticação (JWT);
3. Cadastro de Endereço de Entrega do usuário;
4. Consulta de Saldo de Pontos e Extrato do usuário;
5. Listagem de produtos disponíveis para resgate;
6. Resgate de produtos (troca);
7. Listagem de pedidos (com status de entrega)
