import React from 'react'
import PageHeader from './PageHeader.jsx'
import CustomSelect from  './CustomSelect.jsx'
import SearchInput from './SearchInput.jsx'
import LanguageSelector from './LanguageSelector.jsx'
import UserGroup from './UserGroup.jsx'

export default function TopBar({page}) {
    return (
        <div className="topBar">
            <PageHeader page={page} />
            <LanguageSelector />
            <UserGroup />
        </div>
    )
}