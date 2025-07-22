# 🚀 velocist.WinForms
<p align="center">
  <img src="https://img.shields.io/badge/License-LGPL%20v3-blue.svg" alt="License: LGPL v3">
  <img src="https://img.shields.io/badge/Author-velocist-green.svg" alt="Author: velocist">
  <img src="https://img.shields.io/badge/.NET-9.0-blueviolet" alt=".NET 9.0">
</p>

> **Librería de utilidades para aplicaciones Windows Forms: extensiones y helpers para controles, manejo de errores, generación de contraseñas, integración de logging y más.**

---

## 📑 Tabla de Contenidos
- [Descripción](#descripcion)
- [Características](#caracteristicas)
- [Instalación y Uso](#instalacion-y-uso)
  - [1. Instalación](#instalacion)
  - [2. Ejemplo de configuración de log4net](#log4net)
  - [3. Ejemplos de uso de extensiones](#extensiones)
- [Notas adicionales](#notas-adicionales)
- [Licencia](#licencia)
- [Autor](#autor)

---

## 📝 Descripción<a name="descripcion"></a>

**velocist.WinForms** es una librería de utilidades para proyectos Windows Forms en .NET que centraliza patrones comunes y buenas prácticas en el desarrollo de aplicaciones de escritorio. Incluye extensiones y helpers para controles, manejo de errores, generación de contraseñas, integración de logging y más.

---

## ✨ Características<a name="caracteristicas"></a>
- Extensiones para controles estándar de WinForms (`TextBox`, `ComboBox`, `DataGridView`, `PictureBox`, `TreeView`, `ProgressBar`, etc.).
- Métodos para limpiar, configurar y autocompletar controles.
- Helpers para inicialización y configuración avanzada de tablas y combos.
- Manejo centralizado de errores y mensajes en la UI.
- Generación y gestión de contraseñas seguras (hash, salt).
- Integración sencilla con log4net para logging.
- Utilidades para formularios: redimensionar, configurar, gestionar modales.
- Compatible con .NET 9.0 y Windows 7.0+.

---

## 🚦 Instalación y Uso<a name="instalacion-y-uso"></a>

### 1. Instalación<a name="instalacion"></a>

Agrega la referencia al proyecto o compila la biblioteca:

```sh
# Desde el directorio raíz del proyecto
# dotnet add reference ../velocist.WinForms/velocist.WinForms.csproj
```

### 2. Ejemplo de configuración de log4net<a name="log4net"></a>

Asegúrate de tener el archivo de configuración en `Settings/log4net.config`:

```xml
<log4net debug="false">
  <appender name="LogFileAppender" type="log4net.Appender.RollingFileAppender">
    <param name="File" value="C:\Logs\Genealogy.log" />
    <param name="AppendToFile" value="true" />
    <rollingStyle value="Size" />
    <maxSizeRollBackups value="10" />
    <maximumFileSize value="10MB" />
    <staticLogFileName value="true" />
    <encoding value="utf-8" />
    <lockingModel type="log4net.Appender.FileAppender+MinimalLock" />
  </appender>
  <appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
    <target value="Console.All" />
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="[%-5level][%type{1}.%M:%line] - %-message%newline" />
    </layout>
  </appender>
  <root>
    <level value="TRACE" additivity="true"/>
    <appender-ref ref="ConsoleAppender" />
    <appender-ref ref="LogFileAppender" />
  </root>
</log4net>
```

### 3. Ejemplos de uso de extensiones<a name="extensiones"></a>

#### Extensiones para TextBox

```csharp
using velocist.WinForms.TextBoxControl;

// Copiar texto al portapapeles
dispatcherTextBox.Copy("Texto a copiar");

// Actualizar consola en un TextBox
miTextBox.UpdateConsole("Mensaje de log", newLine: true, inicio: false);

// Autocompletar un TextBox con datos de un DataTable
miTextBox.AutocompleteTextox("NombreColumna", miDataTable);
```

#### Extensiones para ComboBox

```csharp
using velocist.WinForms.ComboBoxControl;

// Cargar un ComboBox con una lista de objetos
tipoComboBox.LoadCombo("Id", "Nombre", listaDeObjetos);
```

#### Extensiones para DataGridView

```csharp
using velocist.WinForms.DataGridViewControl;

// Inicializar columnas manualmente
dataGridView1.InitTable(new Dictionary<int, object> {
    { 0, new DataGridViewTextBoxColumn { Name = "Col1", HeaderText = "Columna 1" } },
    { 1, new DataGridViewTextBoxColumn { Name = "Col2", HeaderText = "Columna 2" } }
});

// Inicializar columnas automáticamente según un modelo
dataGridView1.InitTable<MiModelo>();

// Configurar tabla
dataGridView1.ConfigureTable(edit: false);

// Cargar datos en la tabla
dataGridView1.LoadTable(listaDeDatos);
```

#### Extensiones para PictureBox

```csharp
using velocist.WinForms.PictureBoxControl;

// Cargar imagen desde archivo
miPictureBox.LoadImage(imagePath: "C:/imagenes/foto.png");
```

#### Extensiones para TreeView (JSON a TreeView)

```csharp
using velocist.WinForms.TreeViewControl;
using Newtonsoft.Json.Linq;

JToken json = JToken.Parse(jsonString);
miTreeView.PopulateTreeViewInline(json);
```

#### Extensiones para ProgressBar

```csharp
using velocist.WinForms.ProgressBarControl;

var helper = new ProgressBarHelper(miBackgroundWorker, miProgressBar);
helper.StartAsyncProgressBar();
// ...
helper.CancelAsyncProgressBar();
```

#### Manejo de errores en la UI

```csharp
using velocist.WinForms.MessageBoxControl;

// Manejar excepciones de UI
Application.ThreadException += ErrorMessageBox.ErrorMessageBox_UIThreadException;
AppDomain.CurrentDomain.UnhandledException += ErrorMessageBox.CurrentDomain_UnhandledException;
```

#### Generación y gestión de contraseñas

```csharp
using velocist.WinForms;

// Generar contraseña, salt y hash
generatedPassword = GeneratedPasswords.Password("12");
generatedSalt = GeneratedPasswords.SaltInput(generatedPassword, "8");
generatedHash = GeneratedPasswords.Hash(generatedPassword, generatedSalt);
```

#### Utilidades para formularios

```csharp
using velocist.WinForms.FormControl;

// Redimensionar formulario
this.ResizeForm(heightRatio: 1.2f, widthRatio: 1.2f);

// Configurar formulario principal
this.ConfigureForm("Título de la ventana");

// Configurar modal
this.ConfigureModal("Título del modal");
```

---

## 📝 Notas adicionales<a name="notas-adicionales"></a>
- Incluye helpers para autocompletado en formularios.
- Helpers para limpiar y poner en solo lectura controles.
- Helpers para manejo de imágenes y nodos de árbol.
- Ejemplo de configuración de logging con log4net incluido.

---

## 📝 Licencia<a name="licencia"></a>

Este proyecto está licenciado bajo la **GNU Lesser General Public License v3.0 (LGPL-3.0)**. Consulta el archivo [LICENSE.txt](./LICENSE.txt) para más detalles.

---

## 👤 Autor<a name="autor"></a>

**velocist**

¿Dudas o sugerencias? Abre un issue o revisa la documentación XML en el código fuente para más detalles.


