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

insert into tbProduto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Kit Basebol', 'Kit de Basebol com 2 tacos e 2 bolas', 25.99, 'images/img1.webp', 25);
insert into tbProduto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Basquete de Dedo', 'Basquete de Dedo para uma ótima diversão', 18.99,'images/img2.webp', 30);
insert into tbProduto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Mini Cesta de Basquete', 'Uma mini cesta de basquete para colocar em sua casa', 35.99, 'images/img3.webp', 17);
insert into tbProduto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Luta de Robô c/ Arena', 'Uma arena onde você pode batalhar contra seu amigo', 39.99, 'images/img4.jpg',40);
insert into tbProduto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Ringue de Luta', 'Um ringue de boxe com 4 bonecos para um confronto', 39.99, 'images/img5.webp', 28);
insert into tbProduto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Futebol de botão', 'Um kit de futebol de botão com 2 times', 22.99, 'images/img6.webp', 12);
