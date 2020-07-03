function getArticleGenerator(articles) {
    return function showNext(){
        if (articles.length) {
            let article = document.createElement('article')
            article.innerHTML = articles[0]
            document.getElementById('content').appendChild(article)
            articles.splice(0, 1)   
        }
    }
}