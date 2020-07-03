function solve(){
    class Balloon{
        constructor(color, gasWeight){
            this.color = color
            this.gasWeight = gasWeight 
        }
    }

    class PartyBalloon extends Balloon{
        constructor(ribbonColor, ribbonLength, color, gasWeight){
            super(ribbonColor, ribbonLength)
            this._ribbon = {color: color, length: gasWeight}
        }

        get ribbon(){
            return this._ribbon
        }
    }

    class BirthdayBalloon extends PartyBalloon{
        constructor(ribbonColor, ribbonLength, color, gasWeight, text){
            super(ribbonColor, ribbonLength, color, gasWeight)
            this._text = text
        }

        get text(){
            return this._text
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    }
}
