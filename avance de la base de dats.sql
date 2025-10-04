create database BDAppGros

 create table Usuario(
IdUsuario int identity(1,1),
NumeroDocumento int not null,Nombres nvarchar(50) not null,
Apellidos varchar(80) not null,Contraseña varchar(50) not null,
IdRol int not null,IdEstado int not null ,IdTipoDocumento int not null);

create table Oferta(
IdOferta int identity(1,1),
Titulo varchar(30) not null, Descripcion varchar(300) not null,
FechaPubicacion datetime not null, FormaPago varchar(20) not null,
ValorOferta decimal not null,FechaInicio date not null,FechaFin date not null,
IdTipoOferta int not null,CantVacanteDisp int not null,
IdEstado int not null, IdUsuario  int not null,
IdPredio int not null,IdUbicacion int not null);

create table Predio(
IdPredio int identity(1,1),
IdentificacionPredial int not null,Descripcion varchar(300),
IdUbicacion int not null,IdUsuario int not null
);

create table Postulacion(
IdPostulacion int identity(1,1),
IdOferta int not null,IdEstado int not null,
FechaPostulacion varchar(20) not null
);

create table Rol(
IdRol int identity(1,1),
NombreRol varchar(30) not null,DescripcionRol varchar(100) not null
);

create table HistorialUsuario(
IdHistorial int identity(1,1), IdUsuario int not null,
IdOferta int not null,IdRol int not null
);

create table TipoDocumento(
IdTipoDocumento int identity(1,1),NombreTipoDocumento varchar(50),
Abreviatura varchar(10) not null
);

create table TipoOcupacion 
(IdTipoOcupacion int identity(1,1),NombreOcupacion varchar(50),
Descripcion varchar(50) not null,Categoria varchar(40) not null
);

create table TipoOferta
(IdTipoOferta int identity(1,1),NombreTipoOferta varchar(50) not null,
Descripcion varchar(200) not null,Categoria varchar(30) not null,
IdEstado int not null
);

Create table Ubicacion
(IdUbicacion int identity(1,1),Departamento varchar(20) not null,
Municipio varchar(30) not null, Corregimiento varchar(30)
);

Create table EvidenciaActividad
(IdEvidencia int identity(1,1),RutaArchivo varchar(50) not null,
Descripcion varchar(100) not null, FechaCargaEvidencia datetime not null,
IdActividad int not null, IdUsuario int not null
);

Create table Penalizacion
(IdPenalizacion int identity(1,1), DescripcionPenalizacion varchar(300) not null,
Fecha date not null,FechaInicioPenalizacion datetime not null,
FechaFinPenalizacion datetime not null, IdEstado int not null,
IdUsuario int not null,IdTipoPenalizacion int not null,
IdOferta int not null, IdReporte int not null
);

create table Estado
(IdEstado int identity(1,1),NombreEstado varchar(30) not null,
Descripcion varchar(100) not null,TipoEstado varchar(30) not null
);

create table Reporte
(IdTipoReporte int identity(1,1),NombreTipoReporte varchar(40) not null,
Descripcion varchar(100)
);

create table ActividadOferta
(IdActividad int identity(1,1),NombreActividad varchar(50) not null,
IdUsuario int not null,IdPredio int not null,IdOferta int not null, 
IdEstado int not null,Descripcion varchar(100) not null
);

Create table TipoPenalizacion
(IdTipoPenalizacion int identity(1,1),NombreTipoPenalizacion varchar(50) not null,
Descripcion varchar(100) not null
);

Create table TipoReporte
(IdTipoReporte int identity (1,1),NombreTipoReporte varchar(50) not null,
Descripcion varchar(200) not null 
);

create table MotivoReporte(
IdMotivoReporte int identity(1,1),IdTipoReporte int not null,
NombreMotivo varchar(300) not null
);


Alter table HistorialUsuario
Add constraint Pk_HistorialUsuario primary key(IdHistorial);

Alter table Postulacion
Add constraint Pk_Postulacion primary key (IdPostulacion);

Alter table Predio
Add constraint Pk_Predio primary key(IdPredio);

Alter table TipoDocumento
Add constraint Pk_TipoDocumento primary key (IdTipoDocumento);

Alter table TipoOcupacion
Add constraint Pk_TipoOcupacion primary key(IdTipoOcupacion);

Alter table Usuario
Add constraint Pk_Usuario primary key(IdUsuario);

Alter table  Oferta
Add constraint Pk_oferta primary key (IdOferta);

Alter table TipoOferta
add constraint Pk_TipoOferta primary key (IdTipoOferta);

Alter table Ubicacion 
add constraint Pk_Ubicacion primary key (IdUbicacion);

Alter table EvidenciaActividad
add constraint Pk_EvidenciaActividad primary key (IdEvidencia);

Alter table Penalizacion
add constraint Pk_Penalizacion primary key (IdPenalizacion);

Alter table Estado
add constraint Pk_Estado primary key (IdEstado);

Alter table TipoReporte
add constraint Pk_TipoReporte primary key (IdTipoReporte);

Alter table TipoPenalizacion
add constraint Pk_TipoPenalizacion primary key (IdTipoPenalizacion)

Alter table MotivoReporte
add constraint Pk_MotivoReporte primary key (IdMotivoReporte);

Alter table ActividadOferta
add constraint Pk_ActividadOferta primary key (IdActividad);

alter table Rol
add constraint Pk_Rol primary key (IdRol);


Alter table HistorialUsuario
add constraint Fk_Usuario_HistorialUsuario foreign key (IdUsuario) references Usuario(IdUsuario),
constraint Fk_Oferta_HistorialUsuario foreign key (IdOferta) references Oferta(IdOferta),
constraint Fk_Rol_HistorialUsuario foreign key (IdRol) references Rol (IdRol);

alter table Postulacion
add Constraint Fk_Oferta_Postulacion foreign key (IdOferta) references Oferta(IdOferta),
constraint Fk_Estado_Postulucion foreign key (IdEstado) references Estado(IdEstado);

alter table Predio
add constraint Fk_Ubicacion_Predio foreign key (Idubicacion) references Ubicacion(IdUbicacion),
constraint Fk_Usuario_Predio foreign key (IdUsuario) references Usuario(IdUsuario);

alter table Usuario
add constraint Fk_Rol_Usuario foreign key (IdRol) references Rol(IdRol),
constraint Fk_TipoDocumento_Usuario foreign key (IdTipoDocumento) references TipoDocumento(IdTipoDocumento);

alter table Oferta
add Constraint Fk_TipoOferta_Oferta foreign key (IdTipoOferta) references TipoOferta(IdTipoOferta),
constraint Fk_Estado_Oferta foreign key (IdEstado) references Estado(IdEstado),
constraint Fk_Usuario_Oferta foreign key (IdUsuario) references Usuario(IdUsuario),
constraint Fk_Predio_Oferta foreign key (IdPredio) references Predio(IdPredio),
constraint Fk_Ubicacion_Oferta foreign key (IdUbicacion) references Ubicacion(IdUbicacion);

alter table TipoOferta
add constraint Fk_Estado_TipoOferta foreign key (IdEstado) references Estado(IdEstado)

alter table EvidenciaActividad
add constraint Fk_Actividad_EvidenciaActividad foreign key (IdActividad) references ActividadOferta(IdActividad),
constraint Fk_Usuario_EvidenciaActividad foreign key (IdUsuario) references ActividadOferta(IdActividad);

alter table ActividadOferta
add constraint Fk_Usuario_ActividadOferta foreign key (IdUsuario) references Usuario(IdUsuario),
constraint Fk_Predio_ActividdOferta foreign key (IdPredio) references Predio(IdPredio),
constraint Fk_Oferta_ActividadOferta foreign key (IdOferta) references Oferta(IdOferta),
constraint Fk_Estado_ActidadOferta foreign key (IdEStado) references Estado(IdEstado)

alter table MotivoReporte
add constraint Fk_TipoReporte_MotivoReporte foreign key (IdTipoReporte) references TipoReporte(IdTipoReporte)


