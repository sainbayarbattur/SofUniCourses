class Kitchen{
    constructor(budget){
        this.budget = budget;
        this.menu = [];
        this.productsInStock = [];
        this.actionsHistory = []; 
    }

    loadProducts(products){
        products.forEach(product => {
            let name = product.split(' ')[0];
            let quantity = Number(product.split(' ')[1]);
            let price = Number(product.split(' ')[2]);

            if (price <= this.budget) {
                if (this.productsInStock[name] === undefined) {
                    this.productsInStock[name] = 0;
                }
                this.productsInStock[name] += quantity;
                this.budget -= price;

                this.actionsHistory.push(`Successfully loaded ${quantity} ${name}`);
            }
            else{
                this.actionsHistory.push(`There was not enough money to load ${quantity} ${name}`);
            }
        });

        return this.actionsHistory.join('\n').trim();
    }

    addToMenu(meal, products, price){
        if (!this.menu[meal]) {
            this.menu[meal] = {price:price, products:products};

            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals on the menu, other ideas?`
        }
        else{
            return `The ${meal} is already in our menu, try something different.`
        }
    }

    showTheMenu(){
        if (Object.keys(this.menu).length === 0) {
            return "Our menu is not ready yet, please come later...";
        }

        let arrayToPrint = [];

        for (const key in this.menu) {
            arrayToPrint.push(`${key} - $ ${this.menu[key].price}`);
        }

        return arrayToPrint.join('\n') + '\n';
    }

    makeTheOrder(meal){
        let menuIncludesMeal;
        for (const key in this.menu) {
            if (key === meal) {
                menuIncludesMeal = this.menu[key];
            }
        }

        if (menuIncludesMeal === undefined) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`
        }

        let mealNeededProducts = menuIncludesMeal.products;

        for (let i = 0; i < mealNeededProducts.length; i++) {
            const product = mealNeededProducts[i];
            const name = product.split(' ')[0];
            const quantity = Number(product.split(' ')[1]);

            let g = this.productsInStock[name];

            if (!Object.keys(this.productsInStock).includes(name) || this.productsInStock[name] < quantity) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }

        for (let i = 0; i < mealNeededProducts.length; i++) {
            const element = mealNeededProducts[i];
            const name = element.split(' ')[0];
            const quantity = Number(element.split(' ')[1]);

            this.productsInStock[name] -= quantity;
        }

        this.budget += menuIncludesMeal.price;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${menuIncludesMeal.price}.`
    }
}