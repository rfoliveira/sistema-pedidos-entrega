# sistema-pedidos-entrega
Sistema de logistica com cadastro de usuários, pedidiso e entregas

Ref.: [Contexto](https://pastebin.com/zSF1S3QJ)

## Descrição
Sistema voltado para gerenciamento de pedidos diversos.

## Premissas 
- [x] Usar SQL Server
- [x] Backend em asp.net core com API REST
- [ ] Front em WebForms
- [x] Cadastro de usuários
- [x] Uso de JWT para autenticação
- [ ] Uso de API ~~dos correios~~ para obtenção do endereço
    Foi usado o site https://opencep.com/v1/{cep} para obtenção do CEP devido à burocracia de se usar a api dos correios inviabilizando a entrega no prazo
    Outra boa e funcional opção: https://brasilapi.com.br/api/cep/v2/{cep}

## Telas
- [ ] Cadastro de usuários
- [ ] Cadastro de pedidos
- [ ] Acompanhamento de pedidos