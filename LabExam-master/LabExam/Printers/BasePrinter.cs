using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    public abstract class BasePrinter
    {
        //Решила не трогать структуру и получить доступ к ней таки образом
        Printer printer;

        private string name, model;

        public BasePrinter(string name, string model)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(name)} is invalid", nameof(name));

            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException($"{nameof(model)} is invalid", nameof(model));

            Name = name;
            Model = model;
        }

        /// <summary>
        /// Публичный set - это очень плохо, но по-другому в методе Add()
        /// в PrinterManager надо реализовывать проверку на то, что пришло,
        /// а это долго
        /// </summary>
        public string Name
        {
            get
            {
                return printer.Name;
            }

            set
            {
                if (ReferenceEquals(name, null))
                {
                    throw new ArgumentNullException(nameof(name));
                }
                this.name = printer.Name;
            }
        }

        /// <summary>
        /// Аналогично с set
        /// </summary>
        public string Model
        {
            get
            {
                return printer.Model;
            }
            set
            {
                if (ReferenceEquals(model, null))
                {
                    throw new ArgumentNullException(nameof(model));
                }
                this.model = printer.Model;
            }
        }

        //Иквелс и хешкод для уникальности в HashSet-е
        public override bool Equals(object obj)
        {
            var printer = obj as BasePrinter;
            return printer != null &&
                   EqualityComparer<Printer>.Default.Equals(this.printer, printer.printer) &&
                   name == printer.name &&
                   model == printer.model;
        }

        public override int GetHashCode()
        {
            var hashCode = -546106881;
            hashCode = hashCode * -1521134295 + EqualityComparer<Printer>.Default.GetHashCode(printer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(model);
            return hashCode;
        }

        //Абстрактный, т.к., наверное, может быть различная реализация печати для разных принтеров
        public abstract void Print(FileStream fs);

        //Абстрактный, т.к., наверное, может быть различная реализация сообщений
        public abstract void Message(string arg);

        //Виртуал - если что-то поменяется, могут перереализовать
        public virtual void Register(PrinterManager printerManager)
        {
            printerManager.Printed += Message;
        }

        public virtual void Unregister(PrinterManager printerManager)
        {
            printerManager.Printed -= Message;
        }
    }
}
