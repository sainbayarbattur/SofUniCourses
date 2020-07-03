function createComputerHierarchy() {
    class Components{
        constructor(manufacturer){
            this.manufacturer = manufacturer
        }
    }

    class Keyboard extends Components{
        constructor(manufacturer, responseTime){
            super(manufacturer)
            this.responseTime = responseTime 
        }
    }

    class Monitor extends Components{
        constructor(manufacturer, width, height){
            super(manufacturer)
            this.width = width
            this.height = height
        }
    }  

    class Battery extends Components{
        constructor(manufacturer, expectedLife){
            super(manufacturer)
            this.expectedLife = expectedLife
        }
    }  

    class Computer{
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace){
            if (new.target === Computer) {
                throw new Error()
            }
            this.manufacturer = manufacturer
            this.processorSpeed = processorSpeed
            this.ram = ram
            this.hardDiskSpace = hardDiskSpace
        }
    }  

    class Laptop extends Computer{
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery){
            super(manufacturer, processorSpeed, ram, hardDiskSpace)
            this.weight=  weight
            this.color = color
            this.battery = battery
        }

        get battery(){
            return this._battery
        }

        set battery(value){
            if (!(value instanceof Battery)) {
                throw new TypeError()
            }
            this._battery = value
        }
    }  

    class Desktop  extends Computer{
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor){
            super(manufacturer, processorSpeed, ram, hardDiskSpace)
            this.keyboard = keyboard
            this.monitor = monitor
        }

        get keyboard(){
            return this._keyboard
        }

        set keyboard(value){
            if (!(value instanceof Keyboard)) {
                throw new TypeError()
            }
            this._keyboard = value
        }
        
        get monitor(){
            return this._monitor
        }

        set monitor(value){
            if (!(value instanceof Monitor)) {
                throw new TypeError()
            }
            this._monitor = value
        }
    }

    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop
    }
}

let laptop = createComputerHierarchy().Laptop
new laptop("Hewlett Packard",2.4,4,0.5,3.12,"Silver","pesho")