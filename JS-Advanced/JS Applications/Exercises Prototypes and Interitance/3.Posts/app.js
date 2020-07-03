function main() {
    class Post{
        constructor(title, content){
            this.title = title
            this.content = content
        }
    
        toString(){
            let str = `Post: ${this.title}\n`   
            str += `Content: ${this.content}\n`
    
            return str
        }
    }
    
    class SocialMediaPost extends Post{
        constructor(title, content, likes, dislikes){
            super(title, content)
            this.likes = likes
            this.dislikes = dislikes
            this.comments = []
        }
    
        addComment(comment){
            this.comments.push(comment)
        }
    
        toString(){
            let toString = super.toString()
            toString += `Rating: ${this.likes - this.dislikes}\n`
    
            if (this.comments.length > 0) {
                toString += `Comments:\n`
        
                for (let i = 0; i < this.comments.length; i++) {
                    const comment = this.comments[i];
        
                    toString += ' * ' + comment + '\n'
                }   
            }
    
            return toString.trim()
        }
    }
    
    class BlogPost extends Post{
        constructor(title, content, views){
            super(title, content)
            this.views = views
        }

        view(){
            this.views++
            return this
        }

        toString(){
            let str = super.toString()
            str += `Views: ${this.views}`

            return str
        }
    }
    
    return {Post, SocialMediaPost, BlogPost}
}