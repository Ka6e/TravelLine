import Angry from '../../assets/icons/twemoji_angry-face.svg?react'
import Grinning from '../../assets/icons/twemoji_slightly-frowning-face.svg?react'
import Neutural from '../../assets/icons/twemoji_neutral-face.svg?react'
import Happy from '../../assets/icons/twemoji_grinning-face-with-big-eyes.svg?react'
import Smiling from '../../assets/icons/twemoji_slightly-smiling-face.svg?react'

type EmojiIconProps = {
    value: number
}

export const EmojiIcon = ({ value }: EmojiIconProps) => {

    const prop: React.SVGProps<SVGSVGElement> = {
        width: 16,
        height: 16,
        className: 'icon'
    }

    switch (value) {
        case 1:
            return <Angry {...prop} />
        case 2:
            return <Grinning {...prop} />
        case 3:
            return <Neutural {...prop} />
        case 4:
            return <Smiling {...prop} />
        case 5:
            return <Happy {...prop} />
        default:
            return <Neutural {...prop} />
    }
}