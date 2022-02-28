BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
CREATE TABLE IF NOT EXISTS "Personas" (
	"PersonaId"	INTEGER NOT NULL,
	"Nombre"	TEXT NOT NULL,
	"Genero"	TEXT NOT NULL,
	"Edad"	INTEGER NOT NULL,
	"Identificacion"	TEXT NOT NULL,
	"Direccion"	TEXT NOT NULL,
	"Telefono"	TEXT NOT NULL,
	CONSTRAINT "PK_Personas" PRIMARY KEY("PersonaId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Clientes" (
	"ClienteId"	INTEGER NOT NULL,
	"Contraseña"	TEXT,
	"Estado"	INTEGER NOT NULL,
	"PersonaId"	INTEGER,
	CONSTRAINT "FK_Clientes_Personas_PersonaId" FOREIGN KEY("PersonaId") REFERENCES "Personas"("PersonaId") ON DELETE RESTRICT,
	CONSTRAINT "PK_Clientes" PRIMARY KEY("ClienteId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Cuentas" (
	"CuentaId"	INTEGER NOT NULL,
	"NumeroCuenta"	INTEGER NOT NULL,
	"TipoCuenta"	TEXT,
	"SaldoInicial"	REAL NOT NULL,
	"Estado"	INTEGER NOT NULL,
	"ClienteId"	INTEGER,
	CONSTRAINT "FK_Cuentas_Clientes_ClienteId" FOREIGN KEY("ClienteId") REFERENCES "Clientes"("ClienteId") ON DELETE RESTRICT,
	CONSTRAINT "PK_Cuentas" PRIMARY KEY("CuentaId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Movimientos" (
	"MovimientoId"	INTEGER NOT NULL,
	"FechaMovimiento"	TEXT NOT NULL,
	"TipoMovimiento"	TEXT,
	"Valor"	REAL NOT NULL,
	"Saldo"	REAL NOT NULL,
	"CuentaId"	INTEGER,
	CONSTRAINT "FK_Movimientos_Cuentas_CuentaId" FOREIGN KEY("CuentaId") REFERENCES "Cuentas"("CuentaId") ON DELETE RESTRICT,
	CONSTRAINT "PK_Movimientos" PRIMARY KEY("MovimientoId" AUTOINCREMENT)
);
INSERT INTO "__EFMigrationsHistory" VALUES ('20220228050922_Initial migration and add tables','5.0.14');
INSERT INTO "Personas" VALUES (1,'test test','masculino',30,'1234567890','Direccion es requerida','02231313');
INSERT INTO "Personas" VALUES (2,'test test','masculino',30,'1234567890','Direccion es requerida','02231313');
INSERT INTO "Clientes" VALUES (8,'1',1,1);
INSERT INTO "Clientes" VALUES (9,'1',1,2);
INSERT INTO "Cuentas" VALUES (4,123,'Ahorros',0.0,1,8);
INSERT INTO "Cuentas" VALUES (5,123,'Ahorros',0.0,1,9);
CREATE INDEX IF NOT EXISTS "IX_Clientes_PersonaId" ON "Clientes" (
	"PersonaId"
);
CREATE INDEX IF NOT EXISTS "IX_Cuentas_ClienteId" ON "Cuentas" (
	"ClienteId"
);
CREATE INDEX IF NOT EXISTS "IX_Movimientos_CuentaId" ON "Movimientos" (
	"CuentaId"
);
COMMIT;
