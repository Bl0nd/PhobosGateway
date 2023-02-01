create database PhobosDB;
use PhobosDB;
create table TipoUsuario(
Id int primary key auto_increment not null,
Descricao varchar (150) not null
);

insert into TipoUsuario (Descricao) values ('Administrador'),('Outros');
update TipoUsuario set Descricao = 'Outros' where Id=2;
select * from TipoUsuario;

create table Usuario(
Id int primary key auto_increment not null,
Nome varchar(150) not null,
Email varchar(150) not null,
Senha char(6) not null,
DataNascUsuario date not null,
UsuarioTp int,
foreign key (UsuarioTp) references TipoUsuario(Id)

);
insert into Usuario (Nome,Email,Senha,DataNascUsuario,UsuarioTp) values ('Marsia','marsia@@email.com','123458','20000819',1),
('Valquirio','valquirio@@email.com','123487','19971128',2),
('Marlucio','marlucio@@email.com','123457','20010322',2),
('Gildemara','gildemara@@email.com','123457','20021124',2),
('Alvanacir','alvanacir@@email.com','123457','19970327',2),
('Jucyleidiane','jucyleidiane@@email.com','123457','19981212',2),
('Ano','ano@@email.com','123457','19990218',2),
('Josiderlei','josiderlei@@email.com','123457','20020826',2),
('Historia','historia@@email.com','123457','19940412',2),
('Alma','alma@@email.com','123457','19890526',2);

update Usuario set Senha = '111120' where Id = 11;
/*like*/
select * from Usuario;
select * from Usuario where Usuario.Nome like 'ç%';
select * from Usuario where Usuario.Nome like '%o';
select * from Usuario where Usuario.Nome like '%r%';
/*inner join - order by*/
select Nome, Email, Descricao from Usuario inner join TipoUsuario on Usuario.UsuarioTp = TipoUsuario.Id order by Usuario.Nome asc;

/*inner join manageAdmin*/
SELECT Usuario.Id, Nome, Senha, Email, DataNascUsuario, Descricao FROM Usuario INNER JOIN TipoUsuario ON Usuario.UsuarioTp = TipoUsuario.Id;

/*Classificacao*/
create table Classificacao(
Id int primary key auto_increment not null,
Descricao varchar (150) not null
);

insert into Classificacao (Descricao) values ('Livre'),('+18');

select * from Classificacao;

create table Filme(
Id int primary key auto_increment not null,
Titulo varchar(150) not null,
Genero varchar(150) not null,
Produtora char(150) not null,
UrlImg varchar(250) not null,
FilmeClassif int,
foreign key (FilmeClassif) references Classificacao(Id)

);
insert into Filme (Titulo,Genero,Produtora,UrlImg,FilmeClassif) values ('Porcos do espaço','Terror','Mondo','C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img1.jpg',2),
('Estranhas bizarrices','Terror','Mondo','C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img2.jpg',2),
('Porcos Depravados','Terror','Mondo','C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img3.jpg',2),
('Ameaça do ar','Ficção','Sirius','C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img4.jpg',1),
('Porcos do espaço','Ficção','Sirius','C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img5.jpg',1),
('Espaço de porcos','Ficção','Sirius','C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img6.jpg',2),
('Vento de plástico','Fantasia','DSR','C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img7.jpg',1),
('Água escura','Fantasia','DSR','C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img8.jpg',1),
('Desesperados 2','Drama','Perfect','C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img9.jpg',2),
('O pior final','Drama','Perfect','C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img10.jpg',1);

select * from Filme;
/*Filme*/
update Filme set UrlImg = 'C:\\Users\\wil.rrsilva\\Desktop\\Phobos\\Phobos.UI\\Image\\img1.jpg' where Id = 1;

/*inner join - order by*/
select Titulo, Genero, Produtora, UrlImg from Filme inner join Classificacao on Filme.FilmeClassif = Classificacao.Id;


