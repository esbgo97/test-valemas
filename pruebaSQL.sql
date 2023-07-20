--Punto 1. Crear y poblar tabla vehculos
create table vehiculos (
	id SERIAL primary KEY,
	marca text,
	modelo int,
	descripcion text
);


insert  into vehiculos (marca, modelo, descripcion) values ('Renault', 2017, 'Sandero RS');
insert  into vehiculos (marca, modelo, descripcion) values ('Ford', 2015, 'Fista ST');
insert  into vehiculos (marca, modelo, descripcion) values ('BMW', 1997, 'E46');
insert  into vehiculos (marca, modelo, descripcion) values ('Mazda', 2022, 'Mazda 3');
insert  into vehiculos (marca, modelo, descripcion) values ('Toyota', 2023, 'Supra MK5');


--Punto 2. Crear vista de vehiculos nuevos
create view vehiculos_nuevos as
	select * from vehiculos
	where modelo >= extract (year from now()) - 5
	order by marca asc;

select * from vehiculos_nuevos 

