drop database Toycom;
create database Toycom;
use Toycom;

create table tbProduto(
	Id int primary key auto_increment,
    Nome varchar(40),
    Descricao varchar(150),
    Preco decimal(8,2),
    ImageUrl varchar(255),
    Estoque int
);

create table tbPedido(
	Id int primary key auto_increment,
    DataPedido datetime,
    Total decimal (8,2),
    Status varchar(50),
    Endereco varchar(120),
    FormaPagto varchar(100),
    Frete decimal (8,2)
); 

create table tbCarrinho(
	Id int primary key auto_increment,
    PedidoId int,
    ProdutoId int,
    Qtd int,
    PrecoUnit decimal(10,2)
); -- Qtd = Quantidade, PrecoUnit = Preco Unitario


select * from tbPedido;
select * from tbProduto;
select * from tbCarrinho;
